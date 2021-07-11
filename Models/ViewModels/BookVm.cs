using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModels
{
    public class BookVm
    {
        public int? Id { get; set; }
        public string Title { get; set;  }
        public IList<AuthorVm> Authors { get; set; }
        public int Year { get; set; }
        public int Pages { get; set;  }
        public string Publisher { get; set; }
    }
}
