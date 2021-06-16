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
      return View();
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





