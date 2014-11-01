using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeShare.BusinessLogic;
using WeShare.BusinessModel;
using WeShare.WebHelper;

namespace WeShare.WebForms
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BLUsers objBlUsers = new BLUsers();
            bool isUserValid = objBlUsers.IsUserValid(txtLoginEmail.Text.Trim(), txtLoginPassword.Text.Trim());
            if (isUserValid)
            {
                UserId = txtLoginEmail.Text.Trim();
                Response.Redirect("Home.aspx");
            }
            else
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Please enter valid login credentials.')", true);
        }

        protected void btnSignUpUser_Click(object sender, EventArgs e)
        {
            UserInfo objUserInfo = new UserInfo()
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                UserId = txtEmailId.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                ContactNumber = txtContactNumber.Text.Trim()
            };
            BLUsers objBlUsers = new BLUsers();
            bool isUserRegistered = objBlUsers.SaveUserDetails(objUserInfo);
            if (!isUserRegistered)
            {
            }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Signup_Alert", "alert('Email Id already registered. Please use a different Email Id.')", true);
        }
    }
}