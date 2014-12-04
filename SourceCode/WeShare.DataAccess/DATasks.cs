using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeShare.BusinessModel;
using System.Data.SqlClient;
using System.Data;

namespace WeShare.DataAccess
{
    public class DATasks : DAHelper
    {
        /// <summary>
        /// Stores the details of the task given by the user into the database
        /// </summary>
        public bool SaveTaskDetails(TaskInfo objTaskInfo)
        {
            //Implementation
            bool isDataSaved = false;
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspTasks;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = null;
                if (objTaskInfo.TaskId > 0)
                {
                    parameters = new SqlParameter[8];
                    parameters[0] = new SqlParameter("@Action", "U");
                    parameters[7] = new SqlParameter("@Task_Id", objTaskInfo.TaskId);
                }
                else
                {
                    parameters = new SqlParameter[7];
                    parameters[0] = new SqlParameter("@Action", "C");
                }

                parameters[1] = new SqlParameter("@Task_Title", objTaskInfo.TaskTitle);
                parameters[2] = new SqlParameter("@Task_Description", objTaskInfo.TaskDescription);
                parameters[3] = new SqlParameter("@Points", objTaskInfo.PointsAllocated);
                parameters[4] = new SqlParameter("@Task_Type", objTaskInfo.TaskType);
                parameters[5] = new SqlParameter("@Is_Task_Recursive", objTaskInfo.IsTaskRecursive);
                parameters[6] = new SqlParameter("@Group_Name", objTaskInfo.GroupName);


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
        /// Returns the list of tasks created
        /// </summary>
        public List<TaskInfo> GetTasksList()
        {
            try
            {
                List<TaskInfo> listTaskInfo = new List<TaskInfo>();
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspTasks;
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
                        TaskInfo objTaskInfo = new TaskInfo()
                        {
                            TaskId = objSqlReader["Task_Id"].ToInt32(),
                            TaskTitle = objSqlReader["Task_Title"].ToStr(),
                            TaskDescription = objSqlReader["Task_Description"].ToStr(),
                            PointsAllocated = Convert.ToDouble(objSqlReader["Points"]),
                            TaskType = objSqlReader["Task_Type"].ToStr(),
                            IsTaskRecursive = objSqlReader["Is_Task_Recursive"].ToBoolean()
                        };
                        listTaskInfo.Add(objTaskInfo);
                    }
                }

                return listTaskInfo;
            }
            finally
            {
                CloseConnection();
            }
        }
        /// <summary>
        /// Returns the list of tasks in the group selected by the User(User can select only the groups to which he belongs) 
        /// </summary>
        public List<TaskInfo> GetTasksByGroupName(string groupName)
        {
            try
            {
                List<TaskInfo> listTaskInfo = new List<TaskInfo>();
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspTasks;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@Action", "GETTASKSBYGROUP");
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
                            PointsAllocated = Convert.ToDouble(objSqlReader["Points"]),
                            TaskType = objSqlReader["Task_Type"].ToStr(),
                            IsTaskRecursive = objSqlReader["Is_Task_Recursive"].ToBoolean()
                        };
                        listTaskInfo.Add(objTaskInfo);
                    }
                }

                return listTaskInfo;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Deletes the task corrsponding to the Task ID of the task deleted by the User
        /// </summary>
        public void DeleteTask(int TaskId)
        {
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = DbConstants.UspTasks;
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@Action", "D");
                parameters[1] = new SqlParameter("@Task_Id", TaskId);
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                objSqlCommand.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }

        }

    }
}
