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
            try
            {
                if (!IsPostBack)
                {
                    bool isSessionExpired = Request.QueryString["IsSessionExpired"].ToBoolean();
                    lblErrorMessage.Visible = isSessionExpired;
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }


        protected void btnSignUpUser_Click(object sender, EventArgs e)
        {
            try
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
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Signup_Alert", "alert('Email Id already registered. Please use a different Email Id.')", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Signup_Alert", "alert('User registered successfully. Please login to access the application.')", true);
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }
    }
}