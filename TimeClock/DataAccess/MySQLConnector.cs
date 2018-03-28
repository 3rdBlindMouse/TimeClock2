
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TimeClock.Models;

namespace TimeClock.DataAccess
{
    public class MySqlConnector : IDataConnection
    {
        private const string db = "millertimesheet";

        public ShiftModel CreateShift(ShiftModel model)
        {

            using (IDbConnection connection = new MySqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@ShiftID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@InStaffID", model.StaffID);
                p.Add("@InLoginTime", model.LoginTime);
                connection.Execute("spCreateShift", p, commandType: CommandType.StoredProcedure);


                // grabs newly created ID from database and returns it as part of the current Person Model
                // https://stackoverflow.com/questions/13151861/fetch-last-inserted-id-form-stored-procedure-in-mysql
                var id = p.Get<int?>("ShiftID");
                model.ShiftID = Convert.ToInt32(id);

                return model;
            }

        }

        public StaffModel CreateStaffModel(StaffModel model)
        {
            throw new NotImplementedException();
        }

        public List<StaffModel> getStaff()
        {
            List<StaffModel> output;
            StaffModel model = new StaffModel();
            using (IDbConnection connection = new MySqlConnection(GlobalConfig.CnnString(db)))
            {                
                output = connection.Query<StaffModel>("spGetStaff", commandType: CommandType.StoredProcedure).ToList();
            }
            return output;
        }

        public StaffModel getStaffModel(string name)
        {
            List<StaffModel> output;
            StaffModel model = new StaffModel();
                using (IDbConnection connection = new MySqlConnection(GlobalConfig.CnnString(db)))
                {
                   var q = new DynamicParameters();
                    q.Add("@INname", name);
                    output = connection.Query<StaffModel>("spGetStaffModels", q, commandType: CommandType.StoredProcedure).ToList();

               }
                foreach (StaffModel sm in output)
                {
                model = sm;
                }
                return model;
        }

        public void Login(StaffModel model)
        {
            using (IDbConnection connection = new MySqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@InStaffID", model.staffID);
                
                connection.Execute("spLoginStaff", p, commandType: CommandType.StoredProcedure);

            }
        }

        public void Logout(StaffModel model)
        {
            using (IDbConnection connection = new MySqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@InStaffID", model.staffID);

                connection.Execute("spLogoutStaff", p, commandType: CommandType.StoredProcedure);

            }
        }

        public void LogoutShift(ShiftModel model)
        {
            using (IDbConnection connection = new MySqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@InStaffID", model.StaffID);
                p.Add("@InLogoutTime", model.LogoutTime);

                connection.Execute("spLogoutShift", p, commandType: CommandType.StoredProcedure);

            }
        }

        public void NewPassword(StaffModel model)
        {
            using (IDbConnection connection = new MySqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@InStaffID", model.staffID);
                p.Add("@InPass", model.pass);              
                connection.Execute("spNewPassword", p, commandType: CommandType.StoredProcedure);
                
            }
        }

        public void ResetPassword(StaffModel model)
        {
            using (IDbConnection connection = new MySqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@InStaffID", model.staffID);
                
                connection.Execute("spResetPassword", p, commandType: CommandType.StoredProcedure);

            }
        }

        public bool ValidatePassword(StaffModel model)
        {
            //int count = 0;

            //using (IDbConnection connection = new MySqlConnection(GlobalConfig.CnnString(db)))
            //{
            //    var p = new DynamicParameters();
            //    p.Add("@staffID", model.staffID);

            //    query = new MySqlCommand("SELECT * FROM test ORDER BY type_ID ASC", this.conn);
            //}
            return false;

        }

        /*
         * CREATORS
         */

        //public StaffModel CreateDivision(StaffModel model)
        //{
        //    using (IDbConnection connection = new MySqlConnection(GlobalConfig.CnnString(db)))
        //    {
        //        var p = new DynamicParameters();
        //        p.Add("@DivisionID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        p.Add("@DivisionName", model.DivisionName);
        //        p.Add("@DivisionNumber", model.DivisionNumber);
        //        connection.Execute("spDivision", p, commandType: CommandType.StoredProcedure);


        //        // grabs newly created ID from database and returns it as part of the current Person Model
        //        // https://stackoverflow.com/questions/13151861/fetch-last-inserted-id-form-stored-procedure-in-mysql
        //        var id = p.Get<int?>("DivisionID");
        //        model.DivisionID = Convert.ToInt32(id);

        //        return model;
        //    }
        //}

        /*
         * GETTERS
         */
        /// <summary>
        /// Gets a List of The Divisions in selected selection (at the moment all Divisions in the DB)
        /// </summary>
        /// <returns>A List of ALL Divisions in MySQL DB</returns>
        //public List<DivisionModel> GetSeasonDivisions(int id)
        //{
        //    List<DivisionModel> output;
        //    using (IDbConnection connection = new MySqlConnection(GlobalConfig.CnnString(db)))
        //    {
        //        var q = new DynamicParameters();
        //        q.Add("@SeasonID", id);
        //        output = connection.Query<DivisionModel>("spGetSeasonDivisions", q, commandType: CommandType.StoredProcedure).ToList();

        //    }
        //    foreach (DivisionModel d in output)
        //    {
        //        d.SeasonID = id;
        //    }
        //    return output;
        //}
        /// <summary>
        /// Gets a List of all the Teams in a Selected Division
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A List of all the Teams in a Selected Division</returns>
        //public List<TeamModel> GetDivisionTeams(SeasonDivisionsModel model)
        //{
        //    List<TeamModel> output;
        //    using (IDbConnection connection = new MySqlConnection(GlobalConfig.CnnString(db)))
        //    {
        //        var p = new DynamicParameters();
        //        p.Add("@InSeasonDivisionsID", model.SeasonDivisionsID);
        //        output = connection.Query<TeamModel>("spGetDivisionTeams", p, commandType: CommandType.StoredProcedure).ToList();

        //        //foreach (TeamModel team in output)
        //        //{
        //        //    p = new DynamicParameters();
        //        //    p.Add("@TeamID", team.TeamID);
        //        //    team.TeamMembers = connection.Query<PersonModel>("spGetRoster", p, commandType: CommandType.StoredProcedure).ToList();
        //        //}
        //    }
        //    return output;
        //}

        /*
         * EDITORS
         */
        /// <summary>
        /// Modifies Division data in MySQL DB
        /// </summary>
        /// <param name="model"></param>
        //public void EditDivision(DivisionModel model)
        //{
        //    using (IDbConnection connection = new MySqlConnection(GlobalConfig.CnnString(db)))
        //    {
        //        var p = new DynamicParameters();
        //        p.Add("@InDivisionID", model.DivisionID);
        //        p.Add("@InDivisionName", model.DivisionName);
        //        p.Add("@InDivisionNumber", model.DivisionNumber);
        //        connection.Execute("spEditDivision", p, commandType: CommandType.StoredProcedure);
        //    }
        //}



    }
    
}


//connection.Open();

//string sp = "spPerson";
//// needed to cast connection as MySqlConnection
//MySqlCommand cmd = new MySqlCommand(sp, (MySqlConnection)connection);
//cmd.CommandType = CommandType.StoredProcedure;
//cmd.Parameters.AddWithValue("@PersonID", 0);
//cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
//cmd.Parameters.AddWithValue("@LastName", model.LastName);
//cmd.Parameters.AddWithValue("@email", model.EmailAddress);
//cmd.Parameters.AddWithValue("@phone", model.ContactNumber);
//cmd.Parameters.AddWithValue("@sex", model.Sex);
//cmd.Parameters.AddWithValue("@DateOfBirth", model.DateOfBirth);
//MySqlDataReader rdr = cmd.ExecuteReader();
//connection.Close();
//return model;
//string sp = "spPerson";
// needed to cast connection as MySqlConnection
//MySqlCommand cmd = new MySqlCommand(sp, (MySqlConnection)connection);
//cmd.CommandType = CommandType.StoredProcedure;
//MySqlDataReader rdr = cmd.ExecuteReader();
//connection.Close();