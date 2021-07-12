using Library.Models;
using Library.Models.DataModels;
using System;
using System.Linq;

namespace Library.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{FirstName="Carson",LastName="Alexander",Age=10, RegistrationDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Meredith",LastName="Alonso", Age=10, RegistrationDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Arturo",LastName="Anand", Age=10, RegistrationDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Gytis",LastName="Barzdukas", Age=10, RegistrationDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Yan",LastName="Li", Age=10, RegistrationDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Peggy",LastName="Justice", Age=10, RegistrationDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Laura",LastName="Norman", Age=10, RegistrationDate=DateTime.Parse("2005-09-01")},
            new Student{FirstName="Nino",LastName="Olivetto", Age=10, RegistrationDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var authors = new Author[]
            {
             new Author{FirstName="Carsons",LastName="Alexanders"}
            };
            foreach (Author a in authors)
            {
                context.Authors.Add(a);
            }
            context.SaveChanges();

         

        }
    }
}