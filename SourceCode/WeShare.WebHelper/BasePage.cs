using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using WeShare.BusinessModel;
namespace WeShare.WebHelper
{
    public class BasePage : Page
    {
        /// <summary>
        /// Property to store the User Id in Session
        /// </summary>
        public string UserId
        {
            set { Session["UserId"] = value; }
            get { return Session["UserId"].ToStr(); }
        }

        protected void ManageException(Exception exception, string sourceMethodName = null)
        {
            if (!(exception is System.Threading.ThreadAbortException))
            {
                ExceptionUtility.LogException(exception, sourceMethodName);
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected DateTime GetEffectiveDate()
        {
            //TODO Modify this to include the user story 3.6
            return DateTime.Today;
        }
    }
}
