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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMyTasks();
                LoadAllTasks();
            }
        }

        private void LoadMyTasks()
        {
            BLTaskAssignment objBlTasks = new BLTaskAssignment();
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx?IsSessionExpired=1");
            }
            List<TaskAssignmentInfo> listTaskInfo = objBlTasks.GetUserTasksByMailId(Session["UserId"].ToString());
            gvMyTasks.DataSource = listTaskInfo;
            gvMyTasks.DataBind();
        }


        private void LoadAllTasks()
        {
            BLTaskAssignment objBlTasks = new BLTaskAssignment();
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            List<TaskAssignmentInfo> listTaskInfo = objBlTasks.GetAllAssignedTasks();
            gvAllTasks.DataSource = listTaskInfo;
            gvAllTasks.DataBind();
        }

        protected void gvMyTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "TaskComplete")
            {
                GridViewRow currentGridRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = currentGridRow.RowIndex;
                int taskId = Convert.ToInt32(gvMyTasks.DataKeys[rowIndex].Values["TaskId"]);
                // Mark the respective task as completed
                BLTaskAssignment objBlTasks = new BLTaskAssignment();
                objBlTasks.UpdateTaskStatus(taskId, "Completed");
                LoadMyTasks();
            }
        }

        protected void gvMyTasks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = gvMyTasks.DataKeys[e.Row.RowIndex].Values["Status"].ToStr();
                if (status.ToLower() == "complete")
                {
                    ImageButton imgMarkComplete = (ImageButton)e.Row.FindControl("imgMarkComplete");
                    imgMarkComplete.Visible = false;
                }
            }
        }



    }
}