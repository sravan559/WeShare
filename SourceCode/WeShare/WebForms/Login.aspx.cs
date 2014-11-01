using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeShare.BusinessLogic;

namespace WeShare.WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user_id = txtLoginEmail.Text;
            string pwd = txtLoginPassword.Text;
            BLUsers objBlUsers = new BLUsers();
            string db_pwd = objBlUsers.check_user(user_id);
            if (pwd == db_pwd)
            {
                Session["UserId"] = txtLoginEmail.Text.Trim();
                Response.Redirect("Home.aspx");
            }
            else
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Please enter valid login credentials.')", true);
        }
    }
}