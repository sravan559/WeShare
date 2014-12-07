using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeShare.BusinessModel;
using WeShare.DataAccess;

namespace WeShare.BusinessLogic
{
    public class BLGroups
    {
        DAGroups objDaGroups = new DAGroups();

        /// <summary>
        /// Used to get the list of groups in which given user is a member
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<GroupInfo> GetGroupsList(string userID)
        {
            return objDaGroups.GetGroupsList(userID);

        }

        /// <summary>
        /// Used to create a new group or to update the existing group name
        /// </summary>
        /// <returns></returns>
        public bool SaveGroup(string userId, string currentNameofGroup, string newNameofGroup = null)
        {
            return objDaGroups.SaveGroup(userId, currentNameofGroup, newNameofGroup);
        }

        /// <summary>
        /// Used to delete a group with the given name
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public bool DeleteGroup(string groupName)
        {
            return objDaGroups.DeleteGroup(groupName);
        }

        /// <summary>
        /// Used to get the list of users who are part of the selected group
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="getActiveUsersOnly">Indicates whether only active users are required</param>
        /// <returns></returns>
        public List<UserInfo> GetUsersListByGroupName(string groupName, bool getActiveUsersOnly = false)
        {
            //Active Users are the ones who are already registered on the site.
            //Users who have been invited to join the group but not yet registered will not be listed if getActiveUsersOnly =true
            return objDaGroups.GetUsersListByGroupName(groupName, getActiveUsersOnly);
        }

        public bool AddUserToGroup(string groupName, string userId, decimal weeklyPoints, DateTime recurrenceStartDate)
        {
            return objDaGroups.AddUserToGroup(groupName, userId, weeklyPoints, recurrenceStartDate);
        }

        public bool DeleteUserFromGroup(string groupName, string userId)
        {
            return objDaGroups.DeleteUserFromGroup(groupName, userId);
        }

        /// <summary>
        /// Used to get the total number of points current user is due to complete
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetPointsDueByUserId(string userId)
        {
            return objDaGroups.GetPointsDueByUserId(userId);
        }
    }
}
