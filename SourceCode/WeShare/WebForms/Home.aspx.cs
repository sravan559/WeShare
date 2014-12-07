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
                    LoadUserDuePoints();
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        //TODo Discuss with Team
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
                    objBlTasks.MarkTaskAsComplete(taskId, GetEffectiveDate());

                    LoadUserDuePoints();
                    
                    // objBlTasks.UpdateTaskPoints(taskPoints, UserId, taskId);
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
                    DateTime duedate = gvMyTasks.DataKeys[e.Row.RowIndex].Values["DueDate"].ToDateTime();

                    if (duedate.Date < GetEffectiveDate())
                    {
                        e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
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
                    objBlTasks.UpdateAssignedTaskDetails(taskId, UserId);
                    LoadRoomMatesTasks();
                    LoadMyTasks();
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        protected void gvAllTasks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string status = gvAllTasks.DataKeys[e.Row.RowIndex].Values["Status"].ToStr();
                    if (status.ToLower() == "completed")
                    {
                        Button btnAssignToSelf = (Button)e.Row.FindControl("btnAssignToSelf");
                        btnAssignToSelf.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        #endregion

        #region User Defined

        /// <summary>
        /// Used to get the list of tasks assigned to the logged in user based on the Email Id
        /// </summary>
        private void LoadMyTasks()
        {
            try
            {
                BLTaskAssignment objBlTasks = new BLTaskAssignment();
                if (string.IsNullOrEmpty(UserId))
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


        /// <summary>
        /// Used to get the list of tasks assigned to other roommates
        /// </summary>
        private void LoadRoomMatesTasks()
        {
            try
            {
                BLTaskAssignment objBlTasks = new BLTaskAssignment();
                if (string.IsNullOrEmpty(UserId))
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

        /// <summary>
        /// Used to get the Weekly points that the user is due to complete
        /// </summary>
        private void LoadUserDuePoints()
        {
            BLGroups objBlGroups = new BLGroups();
            decimal points = objBlGroups.GetPointsDueByUserId(UserId);
            ltlWeeklyPoints.Text = points.ToStr();
        }

        #endregion
    }
}