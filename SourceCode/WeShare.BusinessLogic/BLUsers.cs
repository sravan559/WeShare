using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeShare.DataAccess;
using WeShare.BusinessModel;

namespace WeShare.BusinessLogic
{
    public class BLUsers
    {
        DAUser objDaUser = null;
        public BLUsers()
        {
            objDaUser = new DAUser();
        }

        /// <summary>
        /// Used to save the details of the new user signing up to the application
        /// </summary>
        /// <param name="objUserInfo"></param>
        /// <returns></returns>
        public bool SaveUserDetails(UserInfo objUserInfo)
        {
            return objDaUser.SaveUserDetails(objUserInfo);
        }

        /// <summary>
        /// Used to get the list of users from the database
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUsersList()
        {
            return objDaUser.GetUsersList();
        }

        /// <summary>
        /// Used to delete a User with the given User ID
        /// </summary>
        /// <param name="userId">Id of the user to be deleted</param>
        public void DeleteUser(string emailId)
        {
            objDaUser.DeleteUser(emailId);
        }

        /// <summary>
        /// Used to validate the login credentials of the User with the given User ID
        /// </summary>
        /// <param name="userId">User Id of the current User</param>
        /// <param name="password">Password of the current User</param>
        /// <returns>True if valid user, false otherwise</returns>
        public bool IsUserValid(string userId, string password)
        {
            return objDaUser.IsUserValid(userId, password);
        }

        public void SaveDateOffset(int dateOffset)
        {
            objDaUser.SaveDateOffset(dateOffset);
        }

        public int GetDateOffset()
        {
            return objDaUser.GetDateOffset();
            

        }

    }
}
