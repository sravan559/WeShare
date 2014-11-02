using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeShare.BusinessModel;
using WeShare.BusinessLogic;

namespace WeShare.WebForms
{
    public partial class ManageTasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTasksList();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TaskInfo objTaskInfo = new TaskInfo()
                {
                    TaskId = hdnTaskId.Value.ToInt32(),
                    TaskTitle = txtTaskName.Text.Trim(),
                    TaskDescription = txtTaskDesc.Text.Trim(),
                    PointsAllocated = Convert.ToInt32(txtTaskPoints.Text.Trim()),
                    TaskType = rbTaskType.Text.Trim(),
                    TaskRecursive = rbTaskRecursive.Text.Trim(),
                };

                BLTasks objTaskBL = new BLTasks();
                objTaskBL.SaveTaskDetails(objTaskInfo);
                ClearControls();
                LoadTasksList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void gvtasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditTask")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                hdnTaskId.Value = gvtasks.DataKeys[rowIndex].Values["TaskId"].ToString();
                txtTaskName.Text = gvtasks.DataKeys[rowIndex].Values["TaskTitle"].ToString();
                txtTaskDesc.Text = gvtasks.DataKeys[rowIndex].Values["TaskDescription"].ToString();
                txtTaskPoints.Text = gvtasks.DataKeys[rowIndex].Values["PointsAllocated"].ToString();
                //rbTaskType.Text = gvtasks.DataKeys[rowIndex].Values["TaskType"].ToString();
                //rbTaskRecursive.Text = gvtasks.DataKeys[rowIndex].Values["TaskRecursive"].ToString();

            }
        }

        private void LoadTasksList()
        {
            BLTasks objUserBl = new BLTasks();
            gvtasks.DataSource = objUserBl.GetTasksList();
            gvtasks.DataBind();
        }

        private void ClearControls()
        {
            hdnTaskId.Value = txtTaskName.Text = txtTaskDesc.Text = txtTaskPoints.Text  = string.Empty;
            rbTaskType.SelectedIndex = -1;
            rbTaskRecursive.SelectedIndex = -1;

        }

        protected void gvtasks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int TaskId = Convert.ToInt32(gvtasks.DataKeys[e.RowIndex].Values["TaskId"].ToString());
                BLTasks objBlTasks = new BLTasks();
                objBlTasks.DeleteTask(TaskId);
                LoadTasksList();
            }
            catch (Exception)
            {
                //Implement logging and display alert to the user
                throw;
            }


        }

      
    }
}