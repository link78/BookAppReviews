using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieWebAppCore.Abstract;
using MovieWebAppCore.Models;

namespace MovieWebAppCore.Controllers
{
    public class BooksController : Controller
    {
        private IBookRepository repo;

        public BooksController(IBookRepository _repo) { repo = _repo; }


        public IActionResult Index()
        {
            var q = repo.Books;

            return View(q);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Genre = new SelectList(repo.Books.Select(p => p.Genre).Distinct());

            return View(repo.Books.FirstOrDefault(b => b.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                repo.SaveMovie(book);
                TempData["message"] = $"{book.Title} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Book());
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var book = repo.DeleteMovie(id);
            if (book != null)
            {
                ViewBag.Message = $"{book.Title} has beed deleted";


            }

            return RedirectToAction("Index");
        }


    }
}