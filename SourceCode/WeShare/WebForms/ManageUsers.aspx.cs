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
        protected void gvUsersInGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Label lblUser = (Label)gvUsersInGroup.Rows[e.RowIndex].FindControl("lblUser");
                BLGroups objBlGroups = new BLGroups();

                bool delete = objBlGroups.DeleteUserFromGroup(ddlGroups.SelectedValue, lblUser.Text);
                LoadUsersInGroup();
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
                bool isSaved = objGroupBL.AddUserToGroup(ddlGroups.SelectedValue, txtUserId.Text.Trim());
                LoadUsersInGroup();
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
            //TODO wright Code to get the groups from database
            BLGroups objBLGroup = new BLGroups();
            listGroups = objBLGroup.GetGroupsList();
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
            List<string> listUsers = objBlGroups.GetUsersListByGroupName(ddlGroups.SelectedValue);
            gvUsersInGroup.DataSource = listUsers;
            gvUsersInGroup.DataBind();
        }
        #endregion

    }
}