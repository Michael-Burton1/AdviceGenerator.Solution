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
        Console.WriteLine("Full quote: " + myQuote);
        List<String> myWordList = new string(myQuote.Where(c => !char.IsPunctuation(c)).ToArray()).Split(" ").ToList();
        Console.WriteLine("Array length: " + myWordList.Count);
        Double wordsToChange = Convert.ToDouble(myWordList.Count) * 0.3;
        Console.WriteLine(wordsToChange);
        for (int i = 0; i < wordsToChange; i++)
        {
          Random _r = new Random();
          int r = _r.Next(min, myWordList.Count - 1);
          Console.WriteLine(r);
          Console.WriteLine("Chosen word: " + myWordList[r]);
          chaosList = Chaos.GetChaosWord(myWordList[r]);
          string _chaosWord;
          if (chaosList.Count > 1)
          {
            _chaosWord = chaosList[_r.Next(min, chaosList.Count - 1)].Word.ToString();
          }
          else
          {
            _chaosWord = myWordList[r];
          }
          Console.WriteLine("Returned word: " + _chaosWord);
          myWordList.RemoveAt(r);
          myWordList.Insert(r, _chaosWord);
          Console.WriteLine(myWordList.ToString());
        }
        return View(myWordList);
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
            quoteList.Insert(i, "uh, uh " + chaosString);
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





