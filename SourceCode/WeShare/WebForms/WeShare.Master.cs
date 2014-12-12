using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeShare.BusinessModel;

namespace WeShare
{
    public partial class WeShare : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userId = Session["UserId"].ToStr();
                if (string.IsNullOrEmpty(userId))
                {
                    Response.Redirect("Login.aspx?IsSessionExpired=1");
                }
            }

        }
    }
}