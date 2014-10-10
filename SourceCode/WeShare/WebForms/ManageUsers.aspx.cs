using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeShare.BusinessModel;
using WeShare.BusinessLogic;

namespace WeShare.WebForms
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsersList();

            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserInfo objUserInfo = new UserInfo()
            {
                EmailId = txtEmailAddress.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                ContactNumber = txtContactNumber.Text.Trim()
            };

            BLUsers objUserBL = new BLUsers();
            objUserBL.SaveUserDetails(objUserInfo);
            ClearControls();
            ScriptManager.RegisterStartupScript(this,this.GetType(), "Alert", "alert('User details saved successfully!')", true);
            LoadUsersList();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUser")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                txtEmailAddress.Text = gvUsers.DataKeys[rowIndex].Values["EmailId"].ToString();
                txtFirstName.Text = gvUsers.DataKeys[rowIndex].Values["FirstName"].ToString();
                txtLastName.Text = gvUsers.DataKeys[rowIndex].Values["LastName"].ToString();
                txtContactNumber.Text = gvUsers.DataKeys[rowIndex].Values["ContactNumber"].ToString();
                txtEmailAddress.Enabled = false;
            }
        }

        private void LoadUsersList()
        {
            BLUsers objUserBl = new BLUsers();
            gvUsers.DataSource = objUserBl.GetUsersList();
            gvUsers.DataBind();
        }

        private void ClearControls()
        {
            txtContactNumber.Text = txtEmailAddress.Text = txtFirstName.Text = txtLastName.Text = string.Empty;
            txtEmailAddress.Enabled = true;
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string emaildId = gvUsers.DataKeys[e.RowIndex].Values["EmailId"].ToStr();
                BLUsers objUserBL = new BLUsers();
                objUserBL.DeleteUser(emaildId);
                LoadUsersList();
            }
            catch (Exception)
            {
                //Implement logging and display alert to the user
                throw;
            }


        }

    }
}