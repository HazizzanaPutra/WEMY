using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEMY.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleID { get; set; }

        public string RoleName { get; set; }
    }
}