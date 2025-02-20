using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Roland1.Models;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Roland1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private NewMovieContext _context;

        public object CategoryName { get; private set; }

        //set temporary context for home controller
        public HomeController(NewMovieContext temp)
        {
            _context = temp;
        }

        //set up the index page with home view
        public IActionResult Index()
        {
            return View();
        }

        //send user to about page with images and links
        public IActionResult About()
        {
            return View();
        }

        //sent user to form to add a new movie (get all the categories for the form drop down)
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", new AddMovie());
        }

        //add or post movie to the database
        [HttpPost]
        public IActionResult AddMovie(AddMovie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(response);
            }

        }


        //get all the movies from the database and display them
        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = _context.Movies
                .Include(c => c.Category)
                .OrderBy(c => c.title).ToList();

            return View(movies);
        }

        //get the movie to edit and send to the form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", recordToEdit);
        }

        //edit the movie and save the changes
        [HttpPost]
        public IActionResult Edit(AddMovie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        //send user to delete page to confirm record deletion
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        //delete the record from the database
        [HttpPost]
        public IActionResult Delete(AddMovie recordToDelete)
        {
            _context.Movies.Remove(recordToDelete);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
