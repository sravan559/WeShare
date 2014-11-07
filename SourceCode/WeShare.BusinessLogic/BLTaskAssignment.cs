﻿using System;
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

        /// <summary>
        /// Construct for Title of the Task
        /// </summary>
        public BLTaskAssignment()
        {
            objDaTaskAssignment = new DATaskAssignment();
        }

        public List<TaskInfo> GetUnassignedTasksByGroup(string groupName)
        {
            return objDaTaskAssignment.GetUnassignedTasksByGroup(groupName);
        }

        public List<TaskAssignmentInfo> GetAssignedTaskList()
        {
            return objDaTaskAssignment.GetAssignedTaskList();
        }

        /// <summary>
        /// Returns the list of assigned tasks based on the group name
        /// </summary>
        public List<TaskAssignmentInfo> GetAssignedTaskListByGroupName(string groupName)
        {
            return objDaTaskAssignment.GetAssignedTaskListByGroupName(groupName);
        }

        public List<TaskAssignmentInfo> GetUserTasksByMailId(string emailId)
        {
            return objDaTaskAssignment.GetUserTasksByMailId(emailId);
        }


        public List<TaskAssignmentInfo> GetAllAssignedTasks()
        {
            return objDaTaskAssignment.GetAllAssignedTasks();
        }

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
