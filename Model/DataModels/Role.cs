using System;
using Microsoft.AspNetCore.Identity;

namespace Library.Model.DataModels
{
    public class Role : IdentityRole<int>
    {
        public RoleValue RoleValue { get; set; }
        public Role()
        {
             
        }
        public Role(string name, RoleValue roleValue)
        {
            this.RoleValue = roleValue;
        }
    }

}