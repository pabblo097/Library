using Library.Interfaces;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index(string searchTerm)
        {
            var booksIndexViewModel = new BooksIndexViewModel
            {
                Books = bookService.GetAllBooksByName(searchTerm)
            };
            return View(booksIndexViewModel);
        }

        [Route("Books/Details/{bookId:int?}")]
        public IActionResult Details(int bookId)
        {
            var book = bookService.GetBookbyId(bookId);

            if (book == null)
            {
                return RedirectToAction("Index");
            }

            var booksDetailsViewModel = new BooksDetailsViewModel
            {
                Book = book
            };

            return View(booksDetailsViewModel);
        }
    }
}
