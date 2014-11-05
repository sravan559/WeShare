using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeShare.BusinessLogic;
using WeShare.BusinessModel;

namespace WeShare.WebForms
{
    public partial class AssignTasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
                LoadUnAssignedTasks();
                LoadAssignedTasks();
            }
        }

        private void LoadUnAssignedTasks()
        {
            ddlTasks.Items.Clear();
            ddlTasks.Items.Add(new ListItem("Select Task", ""));
            BLTaskAssignment objBlTasks = new BLTaskAssignment();
            List<TaskInfo> listTask = objBlTasks.GetUnassignedTasks();
            ddlTasks.DataSource = listTask;
            ddlTasks.DataTextField = "TaskTitle";
            ddlTasks.DataValueField = "TaskId";
            ddlTasks.DataBind();
        }

        private void LoadUsers()
        {
            ddlUsers.Items.Clear();
            ddlUsers.Items.Add(new ListItem("Select User", ""));
            BLUsers objUserBl = new BLUsers();
            List<UserInfo> listUsers = objUserBl.GetUsersList();
            ddlUsers.DataSource = listUsers;
            ddlUsers.DataTextField = "Name";
            ddlUsers.DataValueField = "UserId";
            ddlUsers.DataBind();
        }

        private void LoadAssignedTasks()
        {
            BLTaskAssignment objBlTasks = new BLTaskAssignment();
            List<TaskAssignmentInfo> listTaskInfo = objBlTasks.GetAssignedTaskList();
            gvAssignedTasks.DataSource = listTaskInfo;
            gvAssignedTasks.DataBind();
                                             
        }

        protected void btnAssignTask_Click(object sender, EventArgs e)
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

        protected void gvAssignedTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditTask")
            {

            }
        }

        protected void gvAssignedTasks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        { 
        
        }


    }
}
