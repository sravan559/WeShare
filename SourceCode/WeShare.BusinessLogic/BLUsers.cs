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
        DAUser objUserDa = null;
        public BLUsers()
        {
            objUserDa = new DAUser();
        }

        public bool SaveUserDetails(UserInfo objUserInfo)
        {
            return objUserDa.SaveUserDetails(objUserInfo);
        }

        public List<UserInfo> GetUsersList()
        {
            return objUserDa.GetUsersList();
        }

        public void DeleteUser(string emailId)
        {
            objUserDa.DeleteUser(emailId);
        }

        public string check_user(string emailId)
        {
            string pwd = objUserDa.VerifyUser(emailId);
            return pwd;
        }
    }
}
