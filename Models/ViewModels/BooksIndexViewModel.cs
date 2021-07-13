using Library.Models.DataModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModels
{
    public class BooksIndexViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public string SearchTerm { get; set; }
    }
}
