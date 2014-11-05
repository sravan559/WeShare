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
                            GroupId = objSqlReader["Group_Id"].ToInt32(),
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
        public bool SaveGroup(GroupInfo objGroupInfo)
        {
            bool isDataSaved = false;
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspGroups;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = null;
                if (objGroupInfo.GroupId > 0)
                {
                    parameters = new SqlParameter[3];
                    parameters[0] = new SqlParameter("@Action", "U");
                    parameters[1] = new SqlParameter("@Group_Id", objGroupInfo.GroupId);
                    parameters[2] = new SqlParameter("@Group_Name", objGroupInfo.GroupName);

                }
                else
                {

                    parameters = new SqlParameter[2];
                    parameters[0] = new SqlParameter("@Action", "C");
                    parameters[1] = new SqlParameter("@Group_Name", objGroupInfo.GroupName);
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
        /// Used to delete a Group for a given GroupID
        /// </summary>
        /// <returns></returns>      

        public bool DeleteGroup(int groupId)
        {
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspGroups;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@Action", "D");
                parameters[1] = new SqlParameter("@Group_Id", groupId);
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                objSqlCommand.ExecuteNonQuery();

            }

            finally
            {
                CloseConnection();
            }
            return true;
        }

        /// <summary>
        /// Used to get the list of users who are part of the selected group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<string> GetUsersListByGroupId(int groupId)
        {
            List<string> listUserIds = new List<string>();
            objSqlConnection = new SqlConnection(GetConnectionString());
            objSqlCommand = objSqlConnection.CreateCommand();
            objSqlCommand.CommandText = DbConstants.UspGroups;
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Action", "GETUSERSINGROUP");
            parameters[1] = new SqlParameter("@Group_Id", groupId);
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
        public bool AddUserToGroup(int groupID, string userId)
        {
            bool isSaved = false;
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspGroups;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@Action", "ADDUSERINGROUP");
                parameters[1] = new SqlParameter("@User_Id", userId);
                parameters[2] = new SqlParameter("@Group_Id", groupID);
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                int rowsAffected = objSqlCommand.ExecuteNonQuery();
                isSaved = rowsAffected > 0;
            }
            finally
            {
                CloseConnection();
            }
            return isSaved;
        }

        /// <summary>
        /// Method to delete a user from the selected group
        /// </summary>
        public bool DeleteUserFromGroup(int groupId, string userId)
        {
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspGroups;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@Action", "DELETEUSERINGROUP");
                parameters[1] = new SqlParameter("@Group_Id", groupId);
                parameters[2] = new SqlParameter("@User_Id", userId);
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                objSqlCommand.ExecuteNonQuery();
            }

            finally
            {
                CloseConnection();
            }
            return true;
        }
    }
}
