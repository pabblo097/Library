using Library.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModels
{
    public class UsersChangeRoleViewModel
    {
        public User User { get; set; }
        public string OldRole { get; set; }
        public RoleValue NewRole { get; set; }

        [EnumDataType(typeof(RoleValue))]
        public RoleValue RoleValues { get; set; }
    }
}
