using AutoMapper;
using Library.DAL;
using Library.Interfaces;
using Library.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
