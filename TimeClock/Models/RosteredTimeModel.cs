using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClock.Models
{
    public class RosteredTimeModel
    {
        public int RosteredTimeID { get; set; }
        public int StaffID { get; set; }
        public DateTime RosteredStart { get; set; }
        public DateTime RosteredEnd { get; set; }
        // either end time or length will be derived 
        public double LengthOfShift { get; set; }
    }
}
