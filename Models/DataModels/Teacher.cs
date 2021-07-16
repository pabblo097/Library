using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.DataModels
{
    public class Teacher : User
    {
      
        public string Title { get; set; }

    }
}
