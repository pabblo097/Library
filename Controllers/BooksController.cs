using Library.DAL;
using Library.Interfaces;
using Library.Models.DataModels;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly UserManager<User> userManager;

        public BooksController(IBookService bookService, UserManager<User> userManager)
        {
            this.bookService = bookService;
            this.userManager = userManager;
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
                return RedirectToAction("Index");

            if (book.Count <= 0)
                TempData["AddMessage"] = "Obecnie książka jest niedostępna.";

            var booksDetailsViewModel = new BooksDetailsViewModel
            {
                Book = book
            };

            return View(booksDetailsViewModel);
        }

        [Authorize(Roles ="Admin, Librarian")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Book book)
        {
            if (ModelState.IsValid)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                if (file != null)
                {
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        book.BookCover = dataStream.ToArray();
                    }
                }

                TempData["AddMessage"] = "Pomyślnie dodano książkę!";
                bookService.AddBook(book);
                return RedirectToAction("Details", new { bookId = book.Id });
            }

            return View(book);
        }

        [Authorize(Roles ="Librarian, Admin")]
        public IActionResult Edit(int id)
        {
            var book = bookService.GetBookbyId(id);

            if (book == null)
                return RedirectToAction("Index");

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Book book)
        {
            if (ModelState.IsValid)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                if (file != null)
                {
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        book.BookCover = dataStream.ToArray();
                    }
                }

                TempData["AddMessage"] = "Edycja książki powiodła się!";
                bookService.EditBook(book);
                return RedirectToAction("Details", new { bookId = book.Id });
            }

            return View(book);
        }

        [Authorize]
        public IActionResult ReservationRequestAsync(int id)
        {
            var book = bookService.GetBookbyId(id);

            if (book == null)
                return RedirectToAction("Index");

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> ReservationRequest(int id)
        {
            var currentLoggedUser = await GetCurrentUser();
            var book = bookService.GetBookbyId(id);

            if (book == null)
                return RedirectToAction("Index");

            if (book.Count <= 0)
            {
                TempData["AddMessage"] = "Obecnie książka jest niedostępna.";
                return RedirectToAction("Details", new { bookId = book.Id });
            }

            TempData["AddMessage"] = "Wysłano prośbę o rezerwację książki.";
            bookService.ReservationRequestService(book, currentLoggedUser);

            return RedirectToAction("Details", new { bookId = book.Id });
        }

        [Authorize(Roles = "Librarian, Admin")]
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
            bookService.DeleteReservations(book);
            bookService.DeleteBook(book);       

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<User> GetCurrentUser()
        {
            var usr = await GetCurrentUserAsync();
            return usr;
        }

        private Task<User> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
    }
}
