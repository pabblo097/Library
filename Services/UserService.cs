using Library.DAL;
using Library.Interfaces;
using Library.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class UserService : IUserService
    {
        private readonly LibraryContext dbContext;

        public UserService(LibraryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Reservation> GetAllReservationRequests()
        {
            return from r in dbContext.Reservations.Include(b => b.Book).Include(u => u.User)
                   select r;
        }

        public IEnumerable<User> GetAllUsersByName(string name)
        {
            return from u in dbContext.Users
                   where string.IsNullOrEmpty(name) || string.Concat(u.FirstName, u.LastName)
                   .ToLower().Contains(name.ToLower())
                   select u;
        }

        public Reservation GetReservationbyId(int id)
        {
            return dbContext.Reservations.FirstOrDefault(b => b.Id == id);
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            if (reservation.ReservationState == ReservationState.Rejected
                || reservation.ReservationState == ReservationState.Returned)
            {
                var book = dbContext.Books.FirstOrDefault(x => x.Id == reservation.BookId);

                book.Count += 1;

                dbContext.Books.Update(book);
                dbContext.SaveChanges();
            }

            dbContext.Reservations.Update(reservation);
            dbContext.SaveChanges();

            return reservation;
        }
    }
}
