using Library.Interfaces;
using Library.Models.DataModels;
using Library.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserService userService;

        public UsersController(IUserService userService, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Librarian")]
        public IActionResult ReservationRequestsAsync(string SearchTerm)
        {
            var reservationRequestsVm = new ReservationRequestsVm()
            {
                Reservations = userService.GetAllReservationRequests(SearchTerm).ToList()
            };

            return View(reservationRequestsVm);
        }

        [Authorize]
        public async Task<IActionResult> MyBooksData(string searchTerm)
        {
            var currentLoggedUser = await GetCurrentUser();

            var reservationRequestsVm = new ReservationRequestsVm()
            {
                Reservations = userService.GetAllReservationRequests(searchTerm)
                .Where(x => x.UserId == currentLoggedUser.Id).ToList()

            };

            return View(reservationRequestsVm);
        }

        public IActionResult PendingOnly(string searchTerm)
        {
            var reservationRequestsVm = new ReservationRequestsVm()
            {
                Reservations = userService.GetAllReservationRequests(searchTerm)
                .Where(x => x.ReservationState == ReservationState.Pending).ToList()
            };

            return View("ReservationRequests", reservationRequestsVm);
        }

        public IActionResult RejectedOnly(string searchTerm)
        {
            var reservationRequestsVm = new ReservationRequestsVm()
            {
                Reservations = userService.GetAllReservationRequests(searchTerm)
                .Where(x => x.ReservationState == ReservationState.Rejected).ToList()
            };

            return View("ReservationRequests", reservationRequestsVm);
        }

        public IActionResult AcceptedOnly(string searchTerm)
        {
            var reservationRequestsVm = new ReservationRequestsVm()
            {
                Reservations = userService.GetAllReservationRequests(searchTerm)
                .Where(x => x.ReservationState == ReservationState.Accepted).ToList()
            };

            return View("ReservationRequests", reservationRequestsVm);
        }

        public IActionResult ReturnedOnly(string searchTerm)
        {
            var reservationRequestsVm = new ReservationRequestsVm()
            {
                Reservations = userService.GetAllReservationRequests(searchTerm)
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

            return RedirectToAction("ReservationRequests");
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

            if (usersListViewModel.Users == null)
            {
                return RedirectToAction("Index", "Books");
            }

            return View(usersListViewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            ViewBag.userId = userId;

            if (user == null)
            {
                return RedirectToAction("List");
            }

            string oldRole = null;

            foreach (var role in roleManager.Roles)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    oldRole = role.Name;
                    break;
                }
            }

            if (string.IsNullOrEmpty(oldRole))
            {
                return RedirectToAction("List");
            }

            var model = new UsersChangeRoleViewModel
            {
                User = user,
                OldRole = oldRole
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ChangeRole(UsersChangeRoleViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.User.Id);

            if (user == null)
            {
                return View("Error");
            }

            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);
            var newRole = model.NewRole.ToString();

            if (!result.Succeeded)
            {
                return View(model);
            }

            result = await userManager.AddToRoleAsync(user, newRole);

            if (!result.Succeeded)
            {
                return View(model);
            }

            return RedirectToAction("List");
        }
    }
}
