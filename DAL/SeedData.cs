using Library.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class SeedData
    {
        //Seeding Roles to DB
        public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(RoleValue.Student.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RoleValue.Reader.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RoleValue.Teacher.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RoleValue.User.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RoleValue.Librarian.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RoleValue.Admin.ToString()));
        }

        public static async Task SeedAdminAsync(UserManager<User> userManager)
        {
            //Seed Default User(Admin)
            var defaultAdmin1 = new User
            {
                Id = "5d12b145-36d4-48df-b6ac-cd1be5077e06",
                UserName = "admin@gmail.com",
                RegistrationDate = DateTime.Now,
                Age = 54,
                Email = "admin@gmail.com",
                FirstName = "Janusz",
                LastName = "Nowak",
                PhoneNumber = "+48657743365",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultAdmin1.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultAdmin1.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultAdmin1, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultAdmin1, RoleValue.Admin.ToString());
                }
            }
        }

        public static async Task SeedLibrarianAsync(UserManager<User> userManager)
        {
            //Seed Default User(Librarian)
            var defaultLibrarian1 = new User
            {
                Id = "4d12b145-36d4-48df-b6ac-cd1be5077e06",
                UserName = "librarian@gmail.com",
                RegistrationDate = DateTime.Now,
                Age = 44,
                Email = "librarian@gmail.com",
                FirstName = "Jan",
                LastName = "Kowalski",
                PhoneNumber = "+48765765432",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultLibrarian1.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultLibrarian1.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultLibrarian1, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultLibrarian1, RoleValue.Librarian.ToString());
                }
            }
        }

        public static async Task SeedStudentAsync(UserManager<User> userManager)
        {
            //Seed Default User(Librarian)
            var defaultStudent1 = new User
            {
                Id = "3d12b145-36d4-48df-b6ac-cd1be5077e06",
                UserName = "student@gmail.com",
                RegistrationDate = DateTime.Now,
                Age = 21,
                Email = "student@gmail.com",
                FirstName = "Mateusz",
                LastName = "Stanchły",
                PhoneNumber = "+48987678874",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultStudent1.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultStudent1.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultStudent1, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultStudent1, RoleValue.Student.ToString());
                }
            }
        }
    }
}

