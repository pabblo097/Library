using Library.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooksByName(string name);
        Book GetBookbyId(int bookId);
        Book AddBook(Book book);
        Book EditBook(Book book);
        Reservation ReservationRequestService(Book book, User user);
        void DeleteReservations(Book book);
        void DeleteBook(Book book);
    }
}
