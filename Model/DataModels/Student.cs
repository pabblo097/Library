using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Model.DataModels
{
    public class Student: User
    {

        public virtual IList<Book> Books { get; set; }
    }
}

