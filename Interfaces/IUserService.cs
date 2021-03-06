using Library.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IUserService
    {
        IQueryable<Reservation> GetAllReservationRequests(string searchTerm);
        Reservation GetReservationbyId(int id);
        Reservation UpdateReservation(Reservation reservation);
        IEnumerable<User> GetAllUsersByName(string name);
        User GetUserById(string id);
    }
}
