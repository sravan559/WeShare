using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeShare.WebHelper;
using WeShare.BusinessLogic;
using WeShare.BusinessModel;

namespace WeShare.WebForms
{
    public partial class ManageUsers : BasePage
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadGroupsList();
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        protected void gvUsersInGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditUser")
                {
                    int rowIndex = e.CommandArgument.ToInt32();
                    txtUserId.Text = txtUserId.Text.Trim();
                    txtWeeklyPoints.Text = gvUsersInGroup.DataKeys[rowIndex].Values["WeeklyPoints"].ToString();
                    DateTime recStartDate = gvUsersInGroup.DataKeys[rowIndex].Values["RecurranceDate"].ToString().ToDateTime();                    
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }
        

        protected void gvUsersInGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string userId = gvUsersInGroup.DataKeys[e.RowIndex].Values["UserId"].ToString();
                BLGroups objBlGroups = new BLGroups();
                bool delete = objBlGroups.DeleteUserFromGroup(ddlGroups.SelectedValue, userId);
                LoadUsersInGroup();
                txtUserId.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BLGroups objGroupBL = new BLGroups();
                if (string.IsNullOrEmpty(ddlGroups.SelectedValue))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert_failure", "alert('Please select a group to add the user!')", true);
                }
                else
                {
                    bool isSaved = objGroupBL.AddUserToGroup(ddlGroups.SelectedValue, txtUserId.Text.Trim(), txtWeeklyPoints.Text.ToDecimal(), txtRecurrenceStartDate.Text.ToDateTime());
                    LoadUsersInGroup();
                    txtUserId.Text = txtWeeklyPoints.Text = string.Empty;
                    if (isSaved)
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert_success", "alert('User added successfully!')", true);
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadUsersInGroup();
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }
        #endregion

        #region User Defined Methods
        private void LoadGroupsList()
        {
            List<GroupInfo> listGroups = new List<GroupInfo>();
            BLGroups objBLGroup = new BLGroups();
            listGroups = objBLGroup.GetGroupsList(UserId);
            ddlGroups.Items.Clear();
            ddlGroups.Items.Add(new ListItem("Select Group", ""));
            ddlGroups.DataTextField = "GroupName";
            ddlGroups.DataValueField = "GroupName";
            ddlGroups.DataSource = listGroups;
            ddlGroups.DataBind();
        }

        private void LoadUsersInGroup()
        {
            BLGroups objBlGroups = new BLGroups();
            List<UserInfo> listUsers = objBlGroups.GetUsersListByGroupName(ddlGroups.SelectedValue);
            gvUsersInGroup.DataSource = listUsers;
            gvUsersInGroup.DataBind();

        }
        #endregion

    }
}