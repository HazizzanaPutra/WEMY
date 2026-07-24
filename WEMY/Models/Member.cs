using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEMY.Models
{
    public class Member
    {
        public int MemberID { get; set; }

        public int UserID { get; set; }

        public DateTime? JoinDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Status { get; set; }
    }
}