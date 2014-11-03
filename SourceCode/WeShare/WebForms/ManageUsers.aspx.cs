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

        }
        protected void gvUsersInGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsersInGroup();
        }
        #endregion

        #region User Defined Methods
        private void LoadGroupsList()
        {
            List<GroupInfo> listGroups = new List<GroupInfo>();
            //TODO wright Code to get the groups from database

            ddlGroups.Items.Clear();
            ddlGroups.Items.Add(new ListItem("Select Group", ""));
            ddlGroups.DataTextField = "GroupName";
            ddlGroups.DataValueField = "GroupId";
            ddlGroups.DataSource = listGroups;
            ddlGroups.DataBind();
        }

        private void LoadUsersInGroup()
        {
            BLGroups objBlGroups = new BLGroups();
            List<string> listUsers = objBlGroups.GetUsersListByGroupId(ddlGroups.SelectedValue.ToInt32());            
            gvUsersInGroup.DataSource = listUsers;
            gvUsersInGroup.DataBind();
        }
        #endregion


    }
}