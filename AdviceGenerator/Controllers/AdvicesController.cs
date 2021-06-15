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
  public class AdvicesController : Controller
  {
    public IActionResult Index()
    {
      var allAdvices = Advice.GetAdvices();
      return View(allAdvices);
    }
    public IActionResult Search()
    {
      return View();
    }
    [HttpPost]
    public IActionResult Search(string searchString)
    {
      var allReviews = Advice.SearchAdvices(searchString);
      return RedirectToAction("Result");
    }
    public IActionResult Result(string searchString)
    {
      var searchAdvice = Advice.SearchAdvices(searchString);
      return View(searchAdvice);
    }
  }
}




