using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModels
{
    public class AddOrEditUserVm
    {
        public int? UserId { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int Age { get; set; }
    }
}
