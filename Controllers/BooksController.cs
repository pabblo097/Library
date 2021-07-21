using Library.DAL;
using Library.Interfaces;
using Library.Models.DataModels;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService, LibraryContext context)
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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                TempData["AddMessage"] = "Pomyślnie dodano książkę!";
                bookService.AddBook(book);
                return RedirectToAction("Details", new { bookId = book.Id });
            }

            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = bookService.GetBookbyId(id);

            if (book == null)
                return RedirectToAction("Index");

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                TempData["AddMessage"] = "Edycja książki powiodła się!";
                bookService.EditBook(book);
                return RedirectToAction("Details", new { bookId = book.Id });
            }

            return View(book);
        }


        public IActionResult Delete(int id)
        {
            var book = bookService.GetBookbyId(id);

            if (book == null)
                return RedirectToAction("Index");

            return View(book);
        }

        // POST: Books1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = bookService.GetBookbyId(id);
            bookService.DeleteBook(book);

            return RedirectToAction("Index");
        }
    }
}
