using Library.Interfaces;
using Library.Models.DataModels;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        [Authorize(Roles = "Admin, Librarian")]
        public IActionResult ReservationRequestsAsync()
        {
            var reservationRequestsVm = new ReservationRequestsVm()
            {
                Reservations = userService.GetAllReservationRequests().ToList()
            };

            return View(reservationRequestsVm);
        }

        [Authorize]
        public async Task<IActionResult> MyBooksData()
        {
            var currentLoggedUser = await GetCurrentUser();

            var reservationRequestsVm = new ReservationRequestsVm()
            {
                Reservations = userService.GetAllReservationRequests()
                .Where(x => x.UserId == currentLoggedUser.Id).ToList()
            };

            return View(reservationRequestsVm);
        }

        public IActionResult PendingOnly()
        {
            var reservationRequestsVm = new ReservationRequestsVm()
            {
                Reservations = userService.GetAllReservationRequests()
                .Where(x => x.ReservationState == ReservationState.Pending).ToList()
            };

            return View("ReservationRequests", reservationRequestsVm);
        }

        public IActionResult RejectedOnly()
        {
            var reservationRequestsVm = new ReservationRequestsVm()
            {
                Reservations = userService.GetAllReservationRequests()
                .Where(x => x.ReservationState == ReservationState.Rejected).ToList()
            };

            return View("ReservationRequests", reservationRequestsVm);
        }

        public IActionResult AcceptedOnly()
        {
            var reservationRequestsVm = new ReservationRequestsVm()
            {
                Reservations = userService.GetAllReservationRequests()
                .Where(x => x.ReservationState == ReservationState.Accepted).ToList()
            };

            return View("ReservationRequests", reservationRequestsVm);
        }

        public IActionResult ReturnedOnly()
        {
            var reservationRequestsVm = new ReservationRequestsVm()
            {
                Reservations = userService.GetAllReservationRequests()
                .Where(x => x.ReservationState == ReservationState.Returned).ToList()
            };

            return View("ReservationRequests", reservationRequestsVm);
        }

        public IActionResult ReservationConfirmed(int id)
        {
            var reservation = userService.GetReservationbyId(id);

            reservation.ReservationState = ReservationState.Accepted;
            reservation.DateOfIssue = DateTime.Now;

            userService.UpdateReservation(reservation);

            return RedirectToAction("ReservationRequests");
        }

        public IActionResult ReservationRejected(int id)
        {
            var reservation = userService.GetReservationbyId(id);

            reservation.ReservationState = ReservationState.Rejected;
            reservation.DateOfIssue = DateTime.Now;

            userService.UpdateReservation(reservation);

            return RedirectToAction("ReservationRequests");
        }

        public IActionResult BookReturned(int id)
        {
            var reservation = userService.GetReservationbyId(id);

            reservation.ReservationState = ReservationState.Returned;
            reservation.DateOfIssue = DateTime.Now;

            userService.UpdateReservation(reservation);

            return RedirectToAction("MyBooksData");
        }

        [HttpGet]
        public async Task<User> GetCurrentUser()
        {
            var usr = await GetCurrentUserAsync();
            return usr;
        }

        private Task<User> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        [Authorize(Roles = "Admin")]
        public IActionResult List(string SearchTerm)
        {
            var usersListViewModel = new UsersListViewModel
            {
                Users = userService.GetAllUsersByName(SearchTerm)
            };

            return View(usersListViewModel);
        }
    }
}
