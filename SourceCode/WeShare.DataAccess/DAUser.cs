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
        public bool SaveUserDetails(UserInfo objUserInfo)
        {
            //Implementation
            SqlConnection objSqlConnection = null;
            bool isRecordSaved = false;
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                SqlCommand objSqlCommand = objSqlConnection.CreateCommand();
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
                CloseConnection(objSqlConnection);
            }

            return isRecordSaved;
        }

        public List<UserInfo> GetUsersList()
        {
            List<UserInfo> listUserInfo = null;
            //Code to get the list of users from the database
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                SqlCommand cmd = objSqlConnection.CreateCommand();
                cmd.CommandText = DbConstants.UspUsers;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Action", "R");
                cmd.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                SqlDataReader objSqlReader = cmd.ExecuteReader();
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
                CloseConnection(objSqlConnection);
            }
            return listUserInfo;
        }

        public void DeleteUser(string userId)
        {
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                SqlCommand cmd = objSqlConnection.CreateCommand();
                cmd.CommandText = DbConstants.UspUsers;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@Action", "D");
                parameters[1] = new SqlParameter("@User_Id", userId);
                cmd.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                cmd.ExecuteNonQuery();

            }
            finally
            {
                CloseConnection(objSqlConnection);
            }
        }

        public bool IsUserValid(string userId, string password)
        {
            bool isValidUser = false;
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                SqlCommand cmd = objSqlConnection.CreateCommand();
                cmd.CommandText = DbConstants.UspUsers;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@Action", "VALIDATEUSER");
                parameters[1] = new SqlParameter("@User_Id", userId);
                parameters[2] = new SqlParameter("@Password", password);
                cmd.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                isValidUser = cmd.ExecuteScalar().ToBoolean();
            }
            finally
            {
                CloseConnection(objSqlConnection);
            }
            return isValidUser;
        }
    }
}
