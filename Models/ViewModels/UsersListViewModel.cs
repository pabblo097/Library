using Library.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModels
{
    public class UsersListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public string SearchTerm { get; set; }
    }
}
