using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.ViewModels
{
    public class AddOrEditBookVm
    {
        [Required]
        public int? BookId { get; set; }
        public string Title { get; set; }
        public int Year { get; set;  }
        public IList<AuthorVm> Authors { get; set; }
        public int Pages { get; set;  }
        public string Publisher { get; set; } 
    }
}
