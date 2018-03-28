using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeClock.Models;

namespace TimeClock.DataAccess
{
    public interface IDataConnection
    {
        StaffModel CreateStaffModel (StaffModel model);

        List<StaffModel> getStaff ();

        bool ValidatePassword(StaffModel model);

        StaffModel getStaffModel(String name);
        void NewPassword(StaffModel model);
        void Login(StaffModel model);
        void Logout(StaffModel model);
        ShiftModel CreateShift(ShiftModel shift);
        void LogoutShift(ShiftModel model);
        void ResetPassword(StaffModel s);
    }
}
