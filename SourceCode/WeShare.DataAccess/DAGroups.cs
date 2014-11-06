using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeShare.BusinessModel;
using System.Data.SqlClient;
using System.Data;

namespace WeShare.DataAccess
{
    public class DAGroups : DAHelper
    {
        /// <summary>
        /// Used to save a new group with its details
        /// </summary>
        /// <returns></returns>
        public List<GroupInfo> GetGroupsList()
        {
            List<GroupInfo> listGroups = new List<GroupInfo>();
            try
            {
                List<TaskInfo> listTaskInfo = new List<TaskInfo>();
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspGroups;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Action", "R");
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                SqlDataReader objSqlReader = objSqlCommand.ExecuteReader();
                if (objSqlReader != null && objSqlReader.HasRows)
                {
                    while (objSqlReader.Read())
                    {
                        GroupInfo objGroupInfo = new GroupInfo()
                        {
                            GroupName = objSqlReader["Group_Name"].ToStr()
                        };

                        listGroups.Add(objGroupInfo);
                    }
                }

                return listGroups;
            }
            finally
            {
                CloseConnection();
            }

        }

        /// <summary>
        /// Used to create a new group or to update the existing group name
        /// </summary>
        /// <returns></returns>
        public bool SaveGroup(string currentNameofGroup, string newNameofGroup)
        {
            bool isDataSaved = false;
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspGroups;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = null;
                if (!string.IsNullOrEmpty(newNameofGroup))
                {
                    parameters = new SqlParameter[3];
                    parameters[0] = new SqlParameter("@Action", "U");
                    parameters[1] = new SqlParameter("@Group_Name", currentNameofGroup);
                    parameters[2] = new SqlParameter("@New_Group_Name", newNameofGroup);

                }
                else
                {
                    parameters = new SqlParameter[2];
                    parameters[0] = new SqlParameter("@Action", "C");
                    parameters[1] = new SqlParameter("@Group_Name", currentNameofGroup);
                }
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                int rowsAffected = objSqlCommand.ExecuteNonQuery();
                isDataSaved = rowsAffected > 0;
            }
            finally
            {
                CloseConnection();
            }
            return isDataSaved;
        }

        /// <summary>
        /// Used to delete a Group for a given groupName
        /// </summary>
        /// <returns></returns>      

        public bool DeleteGroup(string groupName)
        {
            bool isRowDeleted = false;
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspGroups;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@Action", "D");
                parameters[1] = new SqlParameter("@Group_Name", groupName);
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                int rowsAffected = objSqlCommand.ExecuteNonQuery();
                isRowDeleted = rowsAffected > 0;
            }
            finally
            {
                CloseConnection();
            }
            return isRowDeleted;
        }

        /// <summary>
        /// Used to get the list of users who are part of the selected group
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public List<string> GetUsersListByGroupName(string groupName, bool getActiveUsersOnly )
        {
            List<string> listUserIds = new List<string>();
            objSqlConnection = new SqlConnection(GetConnectionString());
            objSqlCommand = objSqlConnection.CreateCommand();
            objSqlCommand.CommandText = DbConstants.UspGroups;
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[2];
            if (getActiveUsersOnly)
                parameters[0] = new SqlParameter("@Action", "GETACTIVEUSERSINGROUP"); // get active users only while assigning the tasks
            else
                parameters[0] = new SqlParameter("@Action", "GETUSERSINGROUP");
            parameters[1] = new SqlParameter("@Group_Name", groupName);
            objSqlCommand.Parameters.AddRange(parameters);
            objSqlConnection.Open();
            SqlDataReader objSqlReader = objSqlCommand.ExecuteReader();
            if (objSqlReader != null && objSqlReader.HasRows)
            {
                string userID;
                while (objSqlReader.Read())
                {
                    userID = objSqlReader["User_Id"].ToStr();
                    listUserIds.Add(userID);
                }
            }
            return listUserIds;
        }



        /// <summary>
        /// Method to add a user to the selected group
        /// </summary>
        public bool AddUserToGroup(string groupName, string userId)
        {
            bool isRecordSaved = false;
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspGroups;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@Action", "ADDUSERTOGROUP");
                parameters[1] = new SqlParameter("@User_Id", userId);
                parameters[2] = new SqlParameter("@Group_Name", groupName);
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
        /// Method to delete a user from the selected group
        /// </summary>
        public bool DeleteUserFromGroup(string groupName, string userId)
        {
            bool isUserDeleted = false;
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspGroups;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@Action", "DELETEUSERINGROUP");
                parameters[1] = new SqlParameter("@Group_Name", groupName);
                parameters[2] = new SqlParameter("@User_Id", userId);
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                int rowsAffected = objSqlCommand.ExecuteNonQuery();
                isUserDeleted = rowsAffected > 0;
            }

            finally
            {
                CloseConnection();
            }
            return isUserDeleted;
        }
    }
}
