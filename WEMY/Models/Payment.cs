using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEMY.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public int OrderID { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentProof { get; set; }

        public string Status { get; set; }
    }
}