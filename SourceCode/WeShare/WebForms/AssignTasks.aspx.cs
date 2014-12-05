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
    public partial class AssignTasks : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadGroups();
                    //LoadUsers();
                    //LoadUnAssignedTasks();
                    //LoadAssignedTasks();
                }
            }
            catch (Exception ex)
            {
                ManageException(ex, "Page_Load");
            }
        }



        protected void btnAssignTask_Click(object sender, EventArgs e)
        {
            try
            {
                TaskAssignmentInfo objTaskAssignmentInfo = new TaskAssignmentInfo()
                {
                    UserId = ddlUsers.SelectedValue,
                    TaskId = ddlTasks.SelectedValue.ToInt32(),
                    DueDate = txtDueDate.Text.Trim().ToDateTime(),
                    Status = "Pending"
                };

                BLTaskAssignment objBlTasks = new BLTaskAssignment();
                objBlTasks.SaveAssignedTaskDetails(objTaskAssignmentInfo);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Task assigned successfully!')", true);
                LoadUnAssignedTasks();
                LoadUsers();
                txtDueDate.Text = string.Empty;
                LoadAssignedTasks();
            }
            catch (Exception ex)
            {
                ManageException(ex, "btnAssignTask_Click");
            }
        }

        protected void gvAssignedTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditTask")
                {

                }
            }

            catch (Exception ex)
            {
                ManageException(ex);
            }

        }
        protected void gvAssignedTasks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }


        #region User Defined Methods

        private void LoadGroups()
        {
            ddlGroups.Items.Clear();
            ddlGroups.Items.Add(new ListItem("Select Group", ""));
            BLGroups objBlGroups = new BLGroups();
            ddlGroups.DataSource = objBlGroups.GetGroupsList(UserId);
            ddlGroups.DataTextField = "GroupName";
            ddlGroups.DataValueField = "GroupName";
            ddlGroups.DataBind();
        }

        private void LoadUnAssignedTasks()
        {
            ddlTasks.Items.Clear();
            ddlTasks.Items.Add(new ListItem("Select Task", ""));
            BLTaskAssignment objBlTasks = new BLTaskAssignment();
            List<TaskInfo> listTask = objBlTasks.GetUnassignedTasksByGroup(ddlGroups.SelectedValue);
            ddlTasks.DataSource = listTask;
            ddlTasks.DataTextField = "TaskTitle";
            ddlTasks.DataValueField = "TaskId";
            ddlTasks.DataBind();
        }

        private void LoadUsers()
        {
            ddlUsers.Items.Clear();
            ddlUsers.Items.Add(new ListItem("Select User", ""));
            BLGroups objBlGroups = new BLGroups();

            ddlUsers.DataSource = objBlGroups.GetUsersListByGroupName(ddlGroups.SelectedValue, true);
            ddlUsers.DataTextField = "Name";
            ddlUsers.DataValueField = "UserId";
            ddlUsers.DataBind();
        }

        private void LoadAssignedTasks()
        {
            BLTaskAssignment objBlTasks = new BLTaskAssignment();
            List<TaskAssignmentInfo> listTaskInfo = objBlTasks.GetAssignedTaskListByGroupName(ddlGroups.SelectedValue);
            gvAssignedTasks.DataSource = listTaskInfo;
            gvAssignedTasks.DataBind();

        }

        #endregion

        protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadUnAssignedTasks();
                LoadUsers();
                LoadAssignedTasks();
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }

        }

    }
}
