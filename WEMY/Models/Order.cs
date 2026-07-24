using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEMY.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public int MemberID { get; set; }

        public int PackageID { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; }
    }
}