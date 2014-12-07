using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeShare.BusinessModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WeShare.DataAccess
{
    public class DAUser : DAHelper
    {

        /// <summary>
        /// Used to save the details of the new user signing up to the application
        /// </summary>
        /// <param name="objUserInfo"></param>
        /// <returns></returns>
        public bool SaveUserDetails(UserInfo objUserInfo)
        {
            //Implementation
            bool isRecordSaved = false;
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspUsers;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[6];
                parameters[0] = new SqlParameter("@Action", "C");
                parameters[1] = new SqlParameter("@User_Id", objUserInfo.UserId);
                parameters[2] = new SqlParameter("@First_Name", objUserInfo.FirstName);
                parameters[3] = new SqlParameter("@Last_Name", objUserInfo.LastName);
                parameters[4] = new SqlParameter("@Contact_Number", objUserInfo.ContactNumber);
                parameters[5] = new SqlParameter("@Password", objUserInfo.Password);
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                int rowsAffected = objSqlCommand.ExecuteNonQuery();
                isRecordSaved = rowsAffected > 0;
            }
            finally
            {
                CloseConnection();
            }
            return isRecordSaved;
        }

        /// <summary>
        /// Used to get the list of users from the database
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUsersList()
        {
            List<UserInfo> listUserInfo = null;
            //Code to get the list of users from the database
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspUsers;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Action", "R");
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                SqlDataReader objSqlReader = objSqlCommand.ExecuteReader();
                if (objSqlReader != null && objSqlReader.HasRows)
                {
                    listUserInfo = new List<UserInfo>();
                    while (objSqlReader.Read())
                    {
                        UserInfo objUserInfo = new UserInfo()
                        {
                            UserId = objSqlReader["User_Id"].ToStr(),
                            FirstName = objSqlReader["First_Name"].ToString(),
                            LastName = objSqlReader["Last_Name"].ToString(),
                            ContactNumber = objSqlReader["Contact_Number"].ToString(),
                            Name = objSqlReader["Name"].ToString()
                        };
                        listUserInfo.Add(objUserInfo);
                    }
                }
            }
            finally
            {
                CloseConnection();
            }
            return listUserInfo;
        }

        /// <summary>
        /// Used to delete a User with the given User ID
        /// </summary>
        /// <param name="userId">Id of the user to be deleted</param>
        public void DeleteUser(string userId)
        {
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspUsers;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@Action", "D");
                parameters[1] = new SqlParameter("@User_Id", userId);
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                objSqlCommand.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Used to validate the login credentials of the User with the given User ID
        /// </summary>
        /// <param name="userId">User Id of the current User</param>
        /// <param name="password">Password of the current User</param>
        /// <returns>True if valid user, false otherwise</returns>
        public bool IsUserValid(string userId, string password)
        {
            bool isValidUser = false;
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                SqlCommand cmd = objSqlConnection.CreateCommand();
                cmd.CommandText = DbConstants.UspUsers;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@Action", "VALIDATEUSER");
                parameters[1] = new SqlParameter("@User_Id", userId);
                parameters[2] = new SqlParameter("@Password", password);
                cmd.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                isValidUser = cmd.ExecuteScalar().ToBoolean();
            }
            finally
            {
                CloseConnection();
            }
            return isValidUser;
        }

        public void SaveDateOffset(int dateOffset)
        {
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspUsers;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@Action", "SAVEDATEOFFSET");
                parameters[1] = new SqlParameter("@Date_Offset", dateOffset);
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                objSqlCommand.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        public int GetDateOffset()
        {
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspUsers;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Action", "GETDATEOFFSET");
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                int dateOffset = objSqlCommand.ExecuteScalar().ToInt32();
                return dateOffset;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
