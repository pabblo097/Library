using Library.Interfaces;
using Library.Models.DataModels;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        public UsersController(IUserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReservationRequests()
        {
            var reservationRequestsVm = new ReservationRequestsVm()
            {
                Reservations = userService.GetAllReservationRequests().ToList()
            };

            return View(reservationRequestsVm);
        }

        public IActionResult ReservationConfirmed(int id)
        {
            var reservation = userService.GetReservationbyId(id);

            reservation.ReservationState = ReservationState.Accepted;

            userService.UpdateReservation(reservation);

            return RedirectToAction("ReservationRequests");
        }

        public IActionResult ReservationRejected(int id)
        {
            var reservation = userService.GetReservationbyId(id);

            reservation.ReservationState = ReservationState.Rejected;

            userService.UpdateReservation(reservation);

            return RedirectToAction("ReservationRequests");
        }
    }
}
