using Microsoft.AspNetCore.Mvc;
using AdviceGenerator.Models;

namespace AdviceGenerator.Controllers
{
  public class SearchController : Controller
  {
    public IActionResult Index()
    {
      //   var allArticles = Article.GetArticles("vB6ng0DLY8JZs6c2NWE4jfgFyc70spUv");
      return View();
    }
  }
}