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

        public List<GroupInfo> GetGroupsList()
        {
            return objDaGroups.GetGroupsList();

        }

        /// <summary>
        /// Used to create a new group or to update the existing group name
        /// </summary>
        /// <returns></returns>
        public bool SaveGroup(string userId,string currentNameofGroup, string newNameofGroup = null)
        {
            return objDaGroups.SaveGroup(userId,currentNameofGroup, newNameofGroup);
        }

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
        public List<string> GetUsersListByGroupName(string groupName, bool getActiveUsersOnly = false)
        {
            //Active Users are the ones who are already registered on the site.
            //Users who have been invited to join the group but not yet registered will not be listed if getActiveUsersOnly =true
            return objDaGroups.GetUsersListByGroupName(groupName, getActiveUsersOnly);
        }

        public bool AddUserToGroup(string groupName, string userId)
        {
            return objDaGroups.AddUserToGroup(groupName, userId);
        }

        public bool DeleteUserFromGroup(string groupName, string userId)
        {
            return objDaGroups.DeleteUserFromGroup(groupName, userId);
        }

    }
}
