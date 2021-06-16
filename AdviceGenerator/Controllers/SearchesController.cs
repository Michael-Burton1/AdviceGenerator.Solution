// using Microsoft.AspNetCore.Mvc;
// using AdviceGenerator.Models;

// namespace AdviceGenerator.Controllers
// {
//   public class SearchController : Controller
//   {
//     public IActionResult Index()
//     {
//       //   var allArticles = Article.GetArticles("vB6ng0DLY8JZs6c2NWE4jfgFyc70spUv");
//      return View();
//     }

//     public IActionResult Search()
//     {
//       return View();
//     }

//     [HttpPost]
//     public IActionResult Search(string searchString)
//     {
//       var allReviews = Advice.SearchAdvices(searchString);
//       return RedirectToAction("Result");
//     }

//     public IActionResult Result(string searchString)
//     {
//       var searchAdvice = Advice.SearchAdvices(searchString);
//       return View(searchAdvice);
//     }

//   }
// }