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
            }
        }

        private void LoadUnAssignedTasks()
        {
            ddlTasks.Items.Clear();
            ddlTasks.Items.Add(new ListItem("Select Task", ""));
            BLTasks objBlTasks = new BLTasks();
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
            ddlUsers.DataTextField = "FirstName";
            ddlUsers.DataValueField = "EmailId";
            ddlUsers.DataBind();
        }

        protected void btnAssignTask_Click(object sender, EventArgs e)
        {
            TaskAssignmentInfo objTaskAssignmentInfo = new TaskAssignmentInfo()
            {
                EmailId = ddlUsers.SelectedValue,
                TaskId = ddlTasks.SelectedValue.ToInt32(),
                DueDate = Convert.ToDateTime(txtDueDate.Text.Trim()),
                Status = "Pending"

            };

            BLTasks objBlTasks = new BLTasks();
            objBlTasks.SaveAssignedTaskDetails(objTaskAssignmentInfo);
            LoadUnAssignedTasks();

        }


    }
}
