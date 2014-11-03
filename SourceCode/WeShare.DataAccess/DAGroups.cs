using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeShare.BusinessModel;

namespace WeShare.DataAccess
{
    public class DAGroups
    {
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

            return true;
        }

        public bool DeleteGroup(int groupId)
        {
            return true;
        }

        /// <summary>
        /// Used to get the list of users who are part of the selected group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<string> GetUsersListByGroupId(int groupId)
        {
            List<string> listUserIds = new List<string>();
            return listUserIds;
        }


        public bool AddUserToGroup(int groupId, string userId)
        {
            return true;
        }

        public bool DeleteUserFromGroup(int groupId, string userId)
        {
            return true;
        }
    }
}
