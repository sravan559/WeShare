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
        public string UserId
        {
            set { Session["UserId"] = value; }
            get { return Session["UserId"].ToStr(); }
        }

    }
}
