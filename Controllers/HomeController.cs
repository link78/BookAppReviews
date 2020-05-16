using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieWebAppCore.Abstract;
using MovieWebAppCore.Models;
using MovieWebAppCore.Models.ViewModels;

namespace MovieWebAppCore.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository repo;

        public HomeController(IBookRepository _repo) { repo = _repo; }

        // GET: /<controller>/
        public IActionResult Index(string search = null)
        {
            var sql = repo.Books.Include(c => c.Author)
                .OrderByDescending(b => b.Reviews.Count())
                .Where(b => search == null || b.Title.StartsWith(search) || b.Genre.StartsWith(search))
                .Select(b => new BookViewIndex
                {
                    Id = b.Id,
                    Title = b.Title,
                    Genre = b.Genre,
                    Price = b.Price,
                    Name = b.Author.Name,
                    Publisher = b.Publiser,
                    BooksCount = b.Author.BooksCount,
                    Year = b.Year,
                    ReviewCount = b.Reviews.Count()
                });



            return View(sql);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var m = repo.getBook(id);


            var model = repo.Books.Include(b => b.Author).Select(b =>
             new BookViewIndex()
             {
                 Id = b.Id,
                 Title = b.Title,
                 Genre = b.Genre,
                 Price = b.Price,
                 Name = b.Author.Name,
                 BooksCount = b.Author.BooksCount,
                 Year = b.Year

             }).FirstOrDefault(b => b.Id == id);
            //.FirstOrDefault(b => b.Id == id);
            // .SingleOrDefault(b => b.Id == id);

            return View(model);
        }
    }
}