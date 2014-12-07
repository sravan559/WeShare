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

        public bool UpdateAssignedTaskDetails(int taskId, string userId, DateTime? dtDueDate = null)
        {
            return objDaTaskAssignment.UpdateAssignedTaskDetails(taskId, userId, dtDueDate);
        }

        public List<TaskAssignmentInfo> GetRoomMatesAssignedTasks(string userID)
        {
            return objDaTaskAssignment.GetRoomMatesAssignedTasks(userID);
        }

        public bool AssignTask(TaskAssignmentInfo objTaskInfo)
        {
            return objDaTaskAssignment.AssignTask(objTaskInfo);
        }

        /// <summary>
        /// Used to mark the task as complete and adjust the pending points of the user accordingly as per business logic
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="taskCompletedDate"></param>
        /// <returns></returns>
        public bool MarkTaskAsComplete(int taskId, DateTime taskCompletedDate)
        {
            //This method adjusts the points user is due to complete by deleting task points of the current task
            return objDaTaskAssignment.MarkTaskAsComplete(taskId, taskCompletedDate);
        }



        public bool UpdateTaskPoints(decimal taskPoints, string userID, int taskId)
        {
            return objDaTaskAssignment.UpdateTaskPoints(taskPoints, userID, taskId);
        }

        public bool UpdatePointsDue(decimal taskpoints, string userid)
        {
            return objDaTaskAssignment.UpdatePointsDue(taskpoints, userid);
        }

    }
}
