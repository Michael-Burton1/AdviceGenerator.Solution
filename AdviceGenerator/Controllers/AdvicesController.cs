using Microsoft.AspNetCore.Mvc;
using AdviceGenerator.Models;

namespace AdviceGenerator.Controllers
{
  public class AdvicesController : Controller
  {
    public IActionResult Random()
    {
      var randomAdvice = Advice.GetAdvices(EnvironmentVariables.ApiKey);
      return View(randomAdvice);
    }
    public IActionResult Searchable(string searchString)
    {
      var searchableAdvice = Advice.GetSearchableAdvices(searchString, EnvironmentVariables.ApiKey);
      return View(searchableAdvice);
    }
  }
}