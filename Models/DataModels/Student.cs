using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.DataModels
{
    public class Student: User
    {

        public virtual IList<Book> Books { get; set; }
    }
}

