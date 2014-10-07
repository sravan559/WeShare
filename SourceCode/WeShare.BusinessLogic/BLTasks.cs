using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeShare.BusinessModel;
using WeShare.DataAccess;

namespace WeShare.BusinessLogic
{
    public class BLTasks
    {
        DATasks objDaTasks = null;

        public BLTasks()
        {
            objDaTasks = new DATasks();
        }


        public bool SaveTaskDetails(TaskInfo objUserInfo)
        {
            return objDaTasks.SaveTaskDetails(objUserInfo);
        }

        public List<TaskInfo> GetTasksList()
        {
            return objDaTasks.GetTasksList();
        }

        public void DeleteTask(int TaskId)
        {
            objDaTasks.DeleteTask(TaskId);
        }

        public List<TaskInfo> GetUnassignedTasks()
        {
            return objDaTasks.GetUnassignedTasks();
        }

        public List<TaskAssignmentInfo> GetUserTasksByMailId(string emailId)
        {
            return objDaTasks.GetUserTasksByMailId(emailId);
        }

        public bool SaveAssignedTaskDetails(TaskAssignmentInfo objTaskInfo)
        {
            return objDaTasks.SaveAssignedTaskDetails(objTaskInfo);
        }

        public bool UpdateTaskStatus(int taskId, string status)
        {
            return objDaTasks.UpdateTaskStatus(taskId, status);
        }
    }
}
