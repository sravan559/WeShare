using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeShare.WebHelper;
using WeShare.BusinessModel;
using WeShare.BusinessLogic;

namespace WeShare.WebForms
{
    public partial class ManageGroups : BasePage
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isGroupCreated = false;
            try
            {
                if (txtGroupName.Text.Trim() == hdnCurrentGroupName.Value)
                {
                    //user has not changed the group name
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert_nochange", "alert('No changes have been made to the group name!')", true);
                    return;
                }
                BLGroups objGroupBL = new BLGroups();
                isGroupCreated = objGroupBL.SaveGroup(hdnCurrentGroupName.Value, txtGroupName.Text.Trim());
                if (isGroupCreated)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert_success", "alert('Group created successfully!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert_failure", "alert('Group with the given name already exists. Please select a different name.!')", true);
                }
                txtGroupName.Text = hdnCurrentGroupName.Value = string.Empty;
                LoadGroupsList();
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        protected void gvUserGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditGroup")
                {
                    GridViewRow currentGridRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = currentGridRow.RowIndex;
                    hdnCurrentGroupName.Value = txtGroupName.Text = gvUserGroups.DataKeys[rowIndex].Values["GroupName"].ToString();

                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        protected void gvUserGroups_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string groupName = gvUserGroups.DataKeys[e.RowIndex].Values["GroupName"].ToString();
                BLGroups objBlGroups = new BLGroups();
                if (objBlGroups.DeleteGroup(groupName))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert_delete", "alert('Group deleted successfully.')", true);
                    LoadGroupsList();
                }

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
            BLGroups objGroupBl = new BLGroups();
            gvUserGroups.DataSource = objGroupBl.GetGroupsList();
            gvUserGroups.DataBind();
        }
        #endregion


    }
}