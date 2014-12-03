using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeShare.BusinessModel;
using System.Data.SqlClient;
using System.Data;

namespace WeShare.DataAccess
{
    public class DATaskAssignment : DAHelper
    {
        /// <summary>
        /// Returns the list of unassigned tasks
        /// </summary>
        public List<TaskInfo> GetUnassignedTasksByGroup(string groupName)
        {
            List<TaskInfo> listTasks = new List<TaskInfo>();
            objSqlConnection = new SqlConnection(GetConnectionString());
            objSqlCommand = objSqlConnection.CreateCommand();
            objSqlCommand.CommandText = DbConstants.UspTaskAssignment;
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Action", "GETUNASSIGNEDTASKSBYGROUP");
            parameters[1] = new SqlParameter("@Group_Name", groupName);

            objSqlCommand.Parameters.AddRange(parameters);
            objSqlConnection.Open();
            SqlDataReader objSqlReader = objSqlCommand.ExecuteReader();
            if (objSqlReader != null && objSqlReader.HasRows)
            {
                while (objSqlReader.Read())
                {
                    TaskInfo objTaskInfo = new TaskInfo()
                    {
                        TaskId = objSqlReader["Task_Id"].ToInt32(),
                        TaskTitle = objSqlReader["Task_Title"].ToStr(),
                        TaskDescription = objSqlReader["Task_Description"].ToStr(),
                        PointsAllocated = objSqlReader["Points"].ToInt32()
                    };
                    listTasks.Add(objTaskInfo);
                }
            }
            return listTasks;
        }

        /// <summary>
        /// Returns the list of assigned tasks
        /// </summary>
        public List<TaskAssignmentInfo> GetAssignedTaskList()
        {
            List<TaskAssignmentInfo> listTasks = new List<TaskAssignmentInfo>();
            objSqlConnection = new SqlConnection(GetConnectionString());
            objSqlCommand = objSqlConnection.CreateCommand();
            objSqlCommand.CommandText = DbConstants.UspTaskAssignment;
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Action", "GETASSIGNEDTASKS");
            objSqlCommand.Parameters.AddRange(parameters);
            objSqlConnection.Open();
            SqlDataReader objSqlReader = objSqlCommand.ExecuteReader();
            if (objSqlReader != null && objSqlReader.HasRows)
            {
                while (objSqlReader.Read())
                {
                    TaskAssignmentInfo objTaskInfo = new TaskAssignmentInfo()
                    {
                        TaskId = objSqlReader["Task_Id"].ToInt32(),
                        TaskTitle = objSqlReader["Task_Title"].ToStr(),
                        TaskDescription = objSqlReader["Task_Description"].ToStr(),
                        UserId = objSqlReader["User_Id"].ToStr(),
                        UserName = objSqlReader["User_Name"].ToStr(),
                        DueDate = objSqlReader["Due_Date"].ToDateTime(),
                        Status = objSqlReader["Status"].ToStr()
                    };
                    listTasks.Add(objTaskInfo);
                }
            }
            return listTasks;
        }

        /// <summary>
        /// Returns the list of assigned tasks based on the group name
        /// </summary>
        public List<TaskAssignmentInfo> GetAssignedTaskListByGroupName(string groupName)
        {
            List<TaskAssignmentInfo> listTasks = new List<TaskAssignmentInfo>();
            objSqlConnection = new SqlConnection(GetConnectionString());
            objSqlCommand = objSqlConnection.CreateCommand();
            objSqlCommand.CommandText = DbConstants.UspTaskAssignment;
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Action", "GETASSIGNEDTASKSBYGROUP");
            parameters[1] = new SqlParameter("@Group_Name", groupName);

            objSqlCommand.Parameters.AddRange(parameters);
            objSqlConnection.Open();
            SqlDataReader objSqlReader = objSqlCommand.ExecuteReader();
            if (objSqlReader != null && objSqlReader.HasRows)
            {
                while (objSqlReader.Read())
                {
                    TaskAssignmentInfo objTaskInfo = new TaskAssignmentInfo()
                    {
                        TaskId = objSqlReader["Task_Id"].ToInt32(),
                        TaskTitle = objSqlReader["Task_Title"].ToStr(),
                        TaskDescription = objSqlReader["Task_Description"].ToStr(),
                        UserId = objSqlReader["User_Id"].ToStr(),
                        UserName = objSqlReader["User_Name"].ToStr(),
                        DueDate = objSqlReader["Due_Date"].ToDateTime(),
                        Status = objSqlReader["Status"].ToStr()
                    };
                    listTasks.Add(objTaskInfo);
                }
            }
            return listTasks;
        }

        /// <summary>
        /// Returns the list of tasks assigned to a user using his/her mailid
        /// </summary>
        public List<TaskAssignmentInfo> GetUserTasksByMailId(string userId)
        {
            List<TaskAssignmentInfo> listTasks = new List<TaskAssignmentInfo>();
            objSqlConnection = new SqlConnection(GetConnectionString());
            objSqlCommand = objSqlConnection.CreateCommand();
            objSqlCommand.CommandText = DbConstants.UspTaskAssignment;
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Action", "GetTasksByEmailId");
            parameters[1] = new SqlParameter("@User_Id", userId);
            objSqlCommand.Parameters.AddRange(parameters);
            objSqlConnection.Open();
            SqlDataReader objSqlReader = objSqlCommand.ExecuteReader();
            if (objSqlReader != null && objSqlReader.HasRows)
            {
                while (objSqlReader.Read())
                {
                    TaskAssignmentInfo objTaskInfo = new TaskAssignmentInfo()
                    {
                        TaskId = objSqlReader["Task_Id"].ToInt32(),
                        TaskTitle = objSqlReader["Task_Title"].ToStr(),
                        PointsAllocated = objSqlReader["Points"].ToInt32(),
                        TaskDescription = objSqlReader["Task_Description"].ToStr(),
                        DueDate = objSqlReader["Due_Date"].ToDateTime(),
                        Status = objSqlReader["Status"].ToStr()
                    };
                    listTasks.Add(objTaskInfo);
                }
            }
            return listTasks;
        }

        /// <summary>
        /// Returns true if a new task with its details is saved by a user
        /// </summary>
        public bool SaveAssignedTaskDetails(TaskAssignmentInfo objTaskInfo)
        {
            //Implementation
            bool isTaskAssigned = false;
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspTaskAssignment;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@Action", "C");
                parameters[1] = new SqlParameter("@Task_Id", objTaskInfo.TaskId);
                parameters[2] = new SqlParameter("@User_Id", objTaskInfo.UserId);
                parameters[3] = new SqlParameter("@Due_Date", objTaskInfo.DueDate);
                parameters[4] = new SqlParameter("@Status", objTaskInfo.Status);
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                int rowsAffected = objSqlCommand.ExecuteNonQuery();
                isTaskAssigned = rowsAffected > 0;
            }
            finally
            {
                CloseConnection();
            }
            return isTaskAssigned;
        }

        public bool ReAssignTaskToOtherUser(int taskId, string userId, DateTime? dtDueDate)
        {
            //Implementation
            bool isTaskReassigned = false;
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspTaskAssignment;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@Action", "REASSIGNTASK");
                parameters[1] = new SqlParameter("@Task_Id", taskId);
                parameters[2] = new SqlParameter("@User_Id", userId);
                if (dtDueDate != null && dtDueDate != DateTime.MinValue)
                    parameters[3] = new SqlParameter("@Due_Date", dtDueDate);
                else
                    parameters[3] = new SqlParameter("@Due_Date", DBNull.Value);

                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                int rowsAffected = objSqlCommand.ExecuteNonQuery();
                isTaskReassigned = rowsAffected > 0;
            }
            finally
            {
                CloseConnection();
            }
            return isTaskReassigned;
        }

        /// <summary>
        /// Returns true if the task details are updated successfully by taskid
        /// </summary>
        public bool UpdateTaskStatus(int taskId, string status)
        {
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspTaskAssignment;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@Action", "UPDATESTATUS");
                parameters[1] = new SqlParameter("@Task_Id", taskId);
                parameters[2] = new SqlParameter("@Status", status);
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                int rows = objSqlCommand.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
            return true;
        }
        /// <summary>
        /// Returns all the tasks assigned to all the Roommates
        /// </summary>
        public List<TaskAssignmentInfo> GetRoomMatesAssignedTasks(string userId)
        {
            List<TaskAssignmentInfo> listTasks = null;
            try
            {

                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspTaskAssignment;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@Action", "GetRoommatesTasks");
                parameters[1] = new SqlParameter("@User_Id", userId);
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                SqlDataReader objSqlReader = objSqlCommand.ExecuteReader();
                if (objSqlReader != null && objSqlReader.HasRows)
                {
                    listTasks = new List<TaskAssignmentInfo>();
                    while (objSqlReader.Read())
                    {
                        TaskAssignmentInfo objTaskInfo = new TaskAssignmentInfo()
                        {
                            TaskId = objSqlReader["Task_Id"].ToInt32(),
                            TaskTitle = objSqlReader["Task_Title"].ToStr(),
                            TaskDescription = objSqlReader["Task_Description"].ToStr(),
                            UserName = objSqlReader["User_Name"].ToStr(),
                            DueDate = objSqlReader["Due_Date"].ToDateTime(),
                            Status = objSqlReader["Status"].ToStr()
                        };
                        listTasks.Add(objTaskInfo);
                    }
                }

            }
            finally
            {
                CloseConnection();
            }
            return listTasks;
        }


    }
}
