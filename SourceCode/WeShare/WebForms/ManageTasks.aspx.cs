using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeShare.BusinessModel;
using WeShare.BusinessLogic;
using WeShare.WebHelper;

namespace WeShare.WebForms
{
    public partial class ManageTasks : BasePage
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadGroups();
                    // LoadTasksList();
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
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

                    IsTaskRecursive = rbtnTaskRecursive.Text.Trim().ToBoolean(),
                    TaskType = rbtnTaskType.SelectedValue.Trim(),
                    GroupName = ddlGroups.SelectedValue
                };

                BLTasks objTaskBL = new BLTasks();
                objTaskBL.SaveTaskDetails(objTaskInfo);
                ClearControls();
                LoadTasksListByGrpName();
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void gvtasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EditTask")
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    hdnTaskId.Value = gvtasks.DataKeys[rowIndex].Values["TaskId"].ToString();
                    txtTaskName.Text = gvtasks.DataKeys[rowIndex].Values["TaskTitle"].ToString();
                    txtTaskDesc.Text = gvtasks.DataKeys[rowIndex].Values["TaskDescription"].ToString();
                    txtTaskPoints.Text = gvtasks.DataKeys[rowIndex].Values["PointsAllocated"].ToString();

                    bool isTaskRecursive = gvtasks.DataKeys[rowIndex].Values["IsTaskRecursive"].ToBoolean();
                    rbtnTaskRecursive.SelectedIndex = isTaskRecursive ? 0 : 1;
                    string taskType = gvtasks.DataKeys[rowIndex].Values["TaskType"].ToStr();
                    switch (taskType)
                    {
                        case "Weekly":
                            rbtnTaskType.SelectedIndex = 0;
                            break;
                        case "Monthy":
                            rbtnTaskType.SelectedIndex = 1;
                            break;
                    }
                    //ddlGroups.SelectedIndex = ddlGroups.Items.IndexOf(ddlGroups.Items.FindByValue(gvtasks.DataKeys[rowIndex].Values["GroupName"].ToString()));
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        protected void gvtasks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int TaskId = Convert.ToInt32(gvtasks.DataKeys[e.RowIndex].Values["TaskId"].ToString());
                BLTasks objBlTasks = new BLTasks();
                objBlTasks.DeleteTask(TaskId);
                LoadTasksListByGrpName();
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTasksListByGrpName();
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }
        #endregion

        #region User Defined Methods
        private void LoadTasksListByGrpName()
        {
            BLTasks objBlUser = new BLTasks();
            gvtasks.DataSource = objBlUser.GetTasksByGroupName(ddlGroups.SelectedValue);
            gvtasks.DataBind();
        }

        private void ClearControls()
        {
            hdnTaskId.Value = txtTaskName.Text = txtTaskDesc.Text = txtTaskPoints.Text = string.Empty;
            rbtnTaskType.SelectedIndex = rbtnTaskRecursive.SelectedIndex = -1;
            ddlGroups.SelectedIndex = 0;
        }

        private void LoadGroups()
        {
            ddlGroups.Items.Clear();
            ddlGroups.Items.Add(new ListItem("Select Group", ""));
            BLGroups objBlGroups = new BLGroups();
            ddlGroups.DataSource = objBlGroups.GetGroupsList();
            ddlGroups.DataTextField = "GroupName";
            ddlGroups.DataValueField = "GroupName";
            ddlGroups.DataBind();
        }
        #endregion
    }
}