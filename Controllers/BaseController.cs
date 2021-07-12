using AutoMapper;
using Library.DAL;
using Library.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Controllers
{
    public class BaseController : Controller
    {
        protected readonly LibraryContext DbContext;
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        protected readonly UserManager<User> UserManager;
        protected readonly RoleManager<IdentityRole> RoleManager;

        public BaseController(ILogger logger,
            IMapper mapper,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            LibraryContext dbContext)
        {
            DbContext = dbContext;
            Logger = logger;
            Mapper = mapper;
            UserManager = userManager;
            RoleManager = roleManager;
        }
    }
}
