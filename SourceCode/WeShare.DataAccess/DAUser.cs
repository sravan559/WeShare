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
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(GetConnectionString());
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "usp_user";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@Action", "C");
                parameters[1] = new SqlParameter("@Email_Id", objUserInfo.EmailId);
                parameters[2] = new SqlParameter("@First_Name", objUserInfo.FirstName);
                parameters[3] = new SqlParameter("@Last_Name", objUserInfo.LastName);
                parameters[4] = new SqlParameter("@Contact_Number", objUserInfo.ContactNumber);
                cmd.Parameters.AddRange(parameters);
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }

            return true;
        }

        public List<UserInfo> GetUsersList()
        {
            List<UserInfo> listUserInfo = new List<UserInfo>();
            //Code to get the list of users from the database

            SqlConnection connection = new SqlConnection(GetConnectionString());

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "usp_user";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Action", "R");
            cmd.Parameters.AddRange(parameters);
            connection.Open();
            SqlDataReader objSqlReader = cmd.ExecuteReader();
            if (objSqlReader != null && objSqlReader.HasRows)
            {
                while (objSqlReader.Read())
                {
                    UserInfo objUserInfo = new UserInfo()
                    {
                        EmailId = objSqlReader["Email_Id"].ToStr(),
                        FirstName = objSqlReader["First_Name"].ToString(),
                        LastName = objSqlReader["Last_Name"].ToString(),
                        ContactNumber = objSqlReader["Contact_Number"].ToString(),
                        Name = objSqlReader["Name"].ToString()
                    };
                    listUserInfo.Add(objUserInfo);
                }
            }

            return listUserInfo;
        }

        public void DeleteUser(string emailId)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "usp_user";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Action", "D");
            parameters[1] = new SqlParameter("@Email_Id", emailId);
            cmd.Parameters.AddRange(parameters);
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public string VerifyUser(string emailId)
        {
            string password = string.Empty;
            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "usp_user";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Action", "CHECK_USER");
            parameters[1] = new SqlParameter("@Email_Id", emailId);
            cmd.Parameters.AddRange(parameters);
            connection.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                password = dataReader["Password"].ToString();
            }

            return password;
        }
    }
}
