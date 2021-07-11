﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.DataModels
{
    public class User: IdentityUser<int>
    {
        [Required]
        public int FirstName { get; set; }
        [Required]
        public int LastName { get; set; }
        public int Age { get; set; }
        public int RegistrationDate { get; set;  }
    }
}
