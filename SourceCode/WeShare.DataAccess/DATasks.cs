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
        SqlConnection objSqlConnection = null;
        SqlCommand objSqlCommand = null;

        public bool SaveTaskDetails(TaskInfo objTaskInfo)
        {
            //Implementation
            try
            {
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = "usp_task";
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] parameters = new SqlParameter[5];
                if (objTaskInfo.TaskId > 0)
                    parameters[0] = new SqlParameter("@Action", "U");
                else
                    parameters[0] = new SqlParameter("@Action", "C");
                parameters[1] = new SqlParameter("@Task_Id", objTaskInfo.TaskId);
                parameters[2] = new SqlParameter("@Task_Title", objTaskInfo.TaskTitle);
                parameters[3] = new SqlParameter("@Task_Description", objTaskInfo.TaskDescription);
                parameters[4] = new SqlParameter("@Points", objTaskInfo.PointsAllocated);
                objSqlCommand.Parameters.AddRange(parameters);
                objSqlConnection.Open();
                objSqlCommand.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection(objSqlConnection);
            }
            return true;
        }

        public List<TaskInfo> GetTasksList()
        {
            try
            {
                List<TaskInfo> listTaskInfo = new List<TaskInfo>();
                objSqlConnection = new SqlConnection(GetConnectionString());
                objSqlCommand = objSqlConnection.CreateCommand();
                objSqlCommand.CommandText = "usp_task";
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
                            PointsAllocated = objSqlReader["Points"].ToInt32()
                        };
                        listTaskInfo.Add(objTaskInfo);
                    }
                }

                return listTaskInfo;
            }
            finally
            {
                CloseConnection(objSqlConnection);
            }
        }

        public void DeleteTask(int TaskId)
        {
            objSqlConnection = new SqlConnection(GetConnectionString());
            objSqlCommand = objSqlConnection.CreateCommand();
            objSqlCommand.CommandText = "usp_task";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Action", "D");
            parameters[1] = new SqlParameter("@Task_Id", TaskId);
            objSqlCommand.Parameters.AddRange(parameters);
            objSqlConnection.Open();
            objSqlCommand.ExecuteNonQuery();
        }

       
       
       
    }
}
