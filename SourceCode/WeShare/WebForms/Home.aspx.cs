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
    public partial class Home : BasePage
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadMyTasks();
                    LoadRoomMatesTasks();
                    LoadMinPoints();
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }
        protected void gvMyTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow currentGridRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                if (e.CommandName == "TaskComplete")
                {
                    int rowIndex = currentGridRow.RowIndex;
                    int taskId = gvMyTasks.DataKeys[rowIndex].Values["TaskId"].ToInt32();
                    // Mark the respective task as completed
                    BLTaskAssignment objBlTasks = new BLTaskAssignment();
                    objBlTasks.UpdateTaskStatus(taskId, "Completed");
                    LoadMyTasks();

                }

            }

            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        protected void gvMyTasks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string status = gvMyTasks.DataKeys[e.Row.RowIndex].Values["Status"].ToStr();
                    if (status.ToLower() == "completed")
                    {
                        ImageButton imgMarkComplete = (ImageButton)e.Row.FindControl("imgMarkComplete");
                        imgMarkComplete.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        protected void gvAllTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "AssignToSelf")
                {
                    GridViewRow currentGridRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = currentGridRow.RowIndex;
                    int taskId = gvAllTasks.DataKeys[rowIndex].Values["TaskId"].ToInt32();
                    BLTaskAssignment objBlTasks = new BLTaskAssignment();
                    objBlTasks.ReAssignTaskToOtherUser(taskId, UserId);
                    LoadRoomMatesTasks();
                    LoadMyTasks();
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        #endregion

        #region User Defined

        private void LoadMyTasks()
        {
            try
            {
                BLTaskAssignment objBlTasks = new BLTaskAssignment();
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Login.aspx?IsSessionExpired=1");
                }
                List<TaskAssignmentInfo> listTaskInfo = objBlTasks.GetUserTasksByMailId(UserId);
                gvMyTasks.DataSource = listTaskInfo;
                gvMyTasks.DataBind();

            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        private void LoadRoomMatesTasks()
        {
            try
            {
                BLTaskAssignment objBlTasks = new BLTaskAssignment();
                if (Session["UserId"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                List<TaskAssignmentInfo> listTaskInfo = objBlTasks.GetRoomMatesAssignedTasks(UserId);
                gvAllTasks.DataSource = listTaskInfo;
                gvAllTasks.DataBind();
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        private void LoadMinPoints()
        {
            BLGroups objBlGroups = new BLGroups();
            int points = objBlGroups.GetMinPoints(UserId);
            ltlMinPoints.Text = points.ToStr();
        }

        #endregion
    }
}