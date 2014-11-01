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

        public bool SaveUserDetails(UserInfo objUserInfo)
        {
            return objDaUser.SaveUserDetails(objUserInfo);
        }

        public List<UserInfo> GetUsersList()
        {
            return objDaUser.GetUsersList();
        }

        public void DeleteUser(string emailId)
        {
            objDaUser.DeleteUser(emailId);
        }

        public bool IsUserValid(string userId, string password)
        {
            return objDaUser.IsUserValid(userId, password);
        }


    }
}
