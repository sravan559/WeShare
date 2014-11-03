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
        public List<TaskInfo> GetUnassignedTasks()
        {
            List<TaskInfo> listTasks = new List<TaskInfo>();
            objSqlConnection = new SqlConnection(GetConnectionString());
            objSqlCommand = objSqlConnection.CreateCommand();
            objSqlCommand.CommandText = DbConstants.UspTaskAssignment;
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Action", "GETUNASSIGNEDTASKS");
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
                objSqlCommand.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
            return true;
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

        public List<TaskAssignmentInfo> GetAllAssignedTasks()
        {
            List<TaskAssignmentInfo> listTasks = null;
            try
            {

                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspTaskAssignment;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@Action", "GetAllTasks");
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
