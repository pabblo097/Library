using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.DataModels
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FirstName { get; set; }
        [Required]
        public int LastName { get; set;  }

    }
}
