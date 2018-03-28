using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClock.Models
{
    public class ShiftModel
    {
        public int ShiftID { get; set; }
        public int StaffID { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }


        public ShiftModel()
        {

        }

    }

   
}
