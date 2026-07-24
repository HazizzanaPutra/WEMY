using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEMY.Models
{
    public class MembershipPlan
    {
        public int PlanID { get; set; }

        public string PlanName { get; set; }

        public decimal Price { get; set; }

        public int DurationMonth { get; set; }

        public string Description { get; set; }
    }
}