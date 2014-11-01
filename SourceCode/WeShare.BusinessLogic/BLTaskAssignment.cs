using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeShare.BusinessModel;
using WeShare.DataAccess;

namespace WeShare.BusinessLogic
{
    public class BLTaskAssignment
    {
        DATaskAssignment objDaTaskAssignment = null;

        public BLTaskAssignment()
        {
            objDaTaskAssignment = new DATaskAssignment();
        }

        public List<TaskInfo> GetUnassignedTasks()
        {
            return objDaTaskAssignment.GetUnassignedTasks();
        }

        public List<TaskAssignmentInfo> GetAssignedTaskList()
        {
            return objDaTaskAssignment.GetAssignedTaskList();
        }

        public List<TaskAssignmentInfo> GetUserTasksByMailId(string emailId)
        {
            return objDaTaskAssignment.GetUserTasksByMailId(emailId);
        }
        public bool Status_Change(int r)
        {
            return objDaTaskAssignment.Status_Change(r);
        }
        //public List<TaskAssignmentInfo> GetCompletedTasksByMailId(string emailId)
        //{
        //    return objDaTaskAssignment.GetCompletedTasksByMailId(emailId);
        //}

        public bool SaveAssignedTaskDetails(TaskAssignmentInfo objTaskInfo)
        {
            return objDaTaskAssignment.SaveAssignedTaskDetails(objTaskInfo);
        }

        public bool UpdateTaskStatus(int taskId, string status)
        {
            return objDaTaskAssignment.UpdateTaskStatus(taskId, status);
        }
    }
}
