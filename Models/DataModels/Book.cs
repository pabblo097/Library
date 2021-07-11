﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.DataModels
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public IList<Author> Authors { get; set; }
        public string Name { get; set; }
        public int Year { get; set;  }
        public int Count { get; set; }
        public string Publisher { get; set; }
    }
}
