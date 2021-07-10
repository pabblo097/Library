using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.DataModels
{
    public class Teacher: User
    {

        public virtual IList<Book> Books { get; set; }

        public string Title { get; set; }

    }
}
