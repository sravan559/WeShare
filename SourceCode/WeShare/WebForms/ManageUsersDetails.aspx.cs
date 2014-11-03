using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeShare.BusinessModel;
using WeShare.BusinessLogic;
using WeShare.WebHelper;

namespace WeShare.WebForms
{
    public partial class ManageUsersDetails : BasePage
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadUsersList();
                }
            }
            catch (Exception ex)
            {
                ManageException(ex, "Page_Load");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo objUserInfo = new UserInfo()
                {
                    UserId = txtEmailAddress.Text.Trim(),
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    ContactNumber = txtContactNumber.Text.Trim()
                };
                BLUsers objUserBL = new BLUsers();
                objUserBL.SaveUserDetails(objUserInfo);
                ClearControls();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('User details saved successfully!')", true);
                LoadUsersList();
            }
            catch (Exception ex)
            {
                ManageException(ex, "btnSave_Click");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
            }
            catch (Exception ex)
            {
                ManageException(ex, "btnSave_Click");
            }
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "EditUser")
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    txtEmailAddress.Text = gvUsers.DataKeys[rowIndex].Values["UserId"].ToString();
                    txtFirstName.Text = gvUsers.DataKeys[rowIndex].Values["FirstName"].ToString();
                    txtLastName.Text = gvUsers.DataKeys[rowIndex].Values["LastName"].ToString();
                    txtContactNumber.Text = gvUsers.DataKeys[rowIndex].Values["ContactNumber"].ToString();
                    txtEmailAddress.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ManageException(ex, "gvUsers_RowCommand");
            }
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
            catch (Exception ex)
            {
                ManageException(ex, "gvUsers_RowDeleting");
            }
        }

        #endregion

        #region User Defined Methods

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

        #endregion
    }
}