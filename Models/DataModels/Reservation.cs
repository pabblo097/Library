using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.DataModels
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set;  }
        public int Status { get; set; }
    }
}
