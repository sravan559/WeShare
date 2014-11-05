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

            if (!IsPostBack)
            {
                LoadGroupsList();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GroupInfo objGroupInfo = new GroupInfo()
                {
                    GroupName = txtGroupName.Text.Trim()
                };

                BLGroups objGroupBL = new BLGroups();
                bool isSaved = objGroupBL.SaveGroup(objGroupInfo);
                txtGroupName.Text = string.Empty;
                LoadGroupsList();
            }
            catch (Exception)
            {
                throw;
            }
        }



        protected void gvUserGroups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditGroup")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                txtGroupName.Text = gvUserGroups.DataKeys[rowIndex].Values["GroupName"].ToString();
            }
        }

        protected void gvUserGroups_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int groupID = Convert.ToInt32(gvUserGroups.DataKeys[e.RowIndex].Values["GroupId"].ToString());
                BLGroups objBlGroups = new BLGroups();
                objBlGroups.DeleteGroup(groupID);
                LoadGroupsList();
            }
            catch (Exception)
            {

                throw;
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