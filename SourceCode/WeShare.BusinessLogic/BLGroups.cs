﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeShare.BusinessModel;
using WeShare.DataAccess;

namespace WeShare.BusinessLogic
{
    public class BLGroups
    {
        DAGroups objDaGroups = null;

        public List<GroupInfo> GetGroupsList()
        {
            List<GroupInfo> listGroups = new List<GroupInfo>();
            return listGroups;
        }

        /// <summary>
        /// Used to create a new group or to update the existing group name
        /// </summary>
        /// <returns></returns>
        public bool SaveGroup(GroupInfo objGroupInfo)
        {

            return objDaGroups.SaveGroup(objGroupInfo);
        }

        public bool DeleteGroup(int groupId)
        {
            return objDaGroups.DeleteGroup(groupId);
        }

        /// <summary>
        /// Used to get the list of users who are part of the selected group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<string> GetUsersListByGroupId(int groupId)
        {
            return objDaGroups.GetUsersListByGroupId(groupId);
        }

        public bool AddUserToGroup(int groupId, string userId)
        {
            return objDaGroups.AddUserToGroup(groupId, userId);
        }

        public bool DeleteUserFromGroup(int groupId, string userId)
        {
            return objDaGroups.DeleteUserFromGroup(groupId, userId);
        }

    }
}