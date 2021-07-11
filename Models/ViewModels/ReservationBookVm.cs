using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModels
{
    public class ReservationBookVm
    {
        public int? Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }

    }
}
