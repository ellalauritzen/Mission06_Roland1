using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Roland.Models;
using Mission06_Roland1.Models;

namespace Mission06_Roland.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private NewMovieContext _context;

        public HomeController(NewMovieContext temp)
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View("AddMovie");
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovie response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home", response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
