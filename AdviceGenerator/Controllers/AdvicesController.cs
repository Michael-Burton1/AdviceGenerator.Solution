using Microsoft.AspNetCore.Mvc;
using AdviceGenerator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace AdviceGenerator.Controllers
{
  public class AdvicesController : Controller
  {
    public IActionResult Index()
    {
      var allAdvices = Advice.GetAdvices();
      return View(allAdvices);
    }
    // public IActionResult Search(string searchString)
    // {
    //   var allAdvices = Advice.GetAdvices();
    //   var results = allAdvices.Where(a => a.Query.Contains(searchString));
    //   return View(results);
    // }
  }
}