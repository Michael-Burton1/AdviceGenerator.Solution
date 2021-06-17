using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AdviceGenerator.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;


namespace AdviceGenerator.Controllers
{
  public class ChaosController : Controller
  {
    public IActionResult Index()
    {
      {
        List<Chaos> chaosList = new List<Chaos>();
        int min = 0;
        var allAdvices = Advice.GetAdvices();
        string myQuote = allAdvices.Contents["quotes"][0]["quote"].ToString();
        ViewBag.quoteAuthor = allAdvices.Contents["quotes"][0]["author"];
        List<String> myOriginalWordList = myQuote.Split(" ").ToList();
        List<String> myWordList = new string(myQuote.Where(c => !char.IsPunctuation(c)).ToArray()).Split(" ").ToList();
        Double wordsToChange = Convert.ToDouble(myWordList.Count) * 0.2;
        for (int i = 0; i < wordsToChange; i++)
        {
          Random _r = new Random();
          int r = _r.Next(min, myWordList.Count - 1);
          chaosList = Chaos.GetChaosWord(myWordList[r]);
          string _chaosWord;
          if (chaosList.Count == 0)
          {
            _chaosWord = myWordList[r];
          }
          else
          {
            _chaosWord = chaosList[0].Word.ToString();
          }
          myOriginalWordList.RemoveAt(r);
          int uh = _r.Next(1, 10);
          if (uh > 4)
          {
            myOriginalWordList.Insert(r, _chaosWord);
          }
          else if (uh == 3)
          {
            myOriginalWordList.Insert(r, "uh, um " + _chaosWord);
          }
          else if (uh == 2)
          {
            myOriginalWordList.Insert(r, "uhh..." + _chaosWord);
          }
          else if (uh == 1)
          {
            myOriginalWordList.Insert(r, "uh, uh " + _chaosWord);
          }
        }
        return View(myOriginalWordList);
      }
    }
    public IActionResult Search()
    {
      return View();
    }
    [HttpPost]
    public IActionResult Search(string searchString)
    {
      return RedirectToAction("Result");
    }
    public IActionResult Result(string searchString)
    {
      try
      {
        var allAdvices = Advice.SearchAdvices(searchString);
        string quoteString = allAdvices.Contents["quotes"][0]["quote"].ToString();
        ViewBag.quoteAuthor = allAdvices.Contents["quotes"][0]["author"];
        var searchChaos = Chaos.GetChaosWord(searchString);
        string chaosString = searchChaos[0].Word.ToString();
        List<string> quoteList = quoteString.Split(" ").ToList();
        for (int i = 0; i < quoteList.Count(); i++)
        {
          if (quoteList[i].ToLower().Contains(searchString.ToLower()))
          {
            quoteList.RemoveAt(i);
            quoteList.Insert(i, "um, uh " + chaosString);
          }
        }
        return View(quoteList);
      }
      catch
      {
        List<string> quoteList = new List<string> { "There", "were", "uh", "uh", "nope", "there", "were", "no", "results" };
        return View(quoteList);
      }
    }
  }
}





