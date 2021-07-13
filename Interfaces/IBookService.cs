using Library.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooksByName(string name);
    }
}
