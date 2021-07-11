using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Library.Models.DataModels
{
    public class Reader: User
    {
        public virtual Book Book { get; set; }

        [ForeignKey("Book")]
        public int? BookId { get; set; }

        public virtual IList<Book> Books { get; set; }

    }       
}
