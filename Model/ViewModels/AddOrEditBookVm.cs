using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library.Model.ViewModels
{
    public class AddOrEditBookVm
    {
        [Required]
        public int? Id { get; set; }

    }
}
