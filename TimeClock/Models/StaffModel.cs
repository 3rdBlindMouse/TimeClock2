using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClock.Models
{
    public class StaffModel
    {
        public int staffID { get; set; }
        // FirstName
        public string name { get; set; }      
        public string pass { get; set; }

        //State (Logged In or Logged Out
        public bool loggedIn { get; set; }

        public StaffModel()
        {

        }

        public StaffModel(string fName, string p, bool torf)
        {
            name = fName;           
            pass = p;
            loggedIn = torf;
        }
    }
}
