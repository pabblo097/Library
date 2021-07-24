using Library.DAL;
using Library.Interfaces;
using Library.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext dbContext;

        public BookService(LibraryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Book> GetAllBooksByName(string name)
        {
            return from b in dbContext.Books
                   where string.IsNullOrEmpty(name) || b.Name.ToLower().Contains(name.ToLower())
                   orderby b.Id
                   select b;
        }

        public Book GetBookbyId(int bookId)
        {
            return dbContext.Books.FirstOrDefault(b => b.Id == bookId);
        }

        public Book AddBook(Book book)
        {

            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            return book;
        }

        public Book EditBook(Book book)
        {
            dbContext.Books.Update(book);
            dbContext.SaveChanges();

            return book;
        }

        public void DeleteBook(Book book)
        {
            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
        }

        public Reservation ReservationRequestService(Book book, User user)
        {
            var reservation = new Reservation()
            {
                BookId = book.Id,
                Book = book,
                UserId = user.Id,
                User = user,
                ReservationState = ReservationState.Pending,
                DateOfIssue = DateTime.Now
            };
            book.Count -= 1;
            dbContext.Reservations.Add(reservation);
            dbContext.Books.Update(book);
            dbContext.SaveChanges();

            return reservation;
        }
    }
}
