using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEMY.Models
{
    public class YogaClass
    {
        public int ClassID { get; set; }

        public string ClassTitle { get; set; }

        public string Theme { get; set; }

        public string Difficulty { get; set; }

        public DateTime ClassDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string Teacher { get; set; }

        public int MaxParticipant { get; set; }
    }
}