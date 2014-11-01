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
               //oadAllTasks();
            }
        }

        private void LoadMyTasks()
        {
            BLTaskAssignment objBlTasks = new BLTaskAssignment();
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            List<TaskAssignmentInfo> listTaskInfo = objBlTasks.GetUserTasksByMailId(Session["UserId"].ToString());
            gvMyTasks.DataSource = listTaskInfo;
            gvMyTasks.DataBind();
        }

        protected void gvMyTasks_RowCommand(object sender,GridViewCommandEventArgs e)
        {
            if (e.CommandName == "StatusChange")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvMyTasks.Rows[index];

                // Mark the respective task as completed


                // Refresh the gridview
                LoadMyTasks();
            }

        }

        //private void LoadAllTasks()
        //{
        //     BLTaskAssignment objBlTasks = new BLTaskAssignment();
        //    if (Session["UserId"] == null)
        //    {
        //        Response.Redirect("Login.aspx");
        //    }
        //    List<TaskAssignmentInfo> listTaskInfo = objBlTasks.GetCompletedTasksByMailId(Session["UserId"].ToString());
        //    gvMyTasks.DataSource = listTaskInfo;
        //    gvMyTasks.DataBind();
        //}
        //protected void gvMyTasks_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BLTaskAssignment objBL = new BLTaskAssignment();
        //    int r =gvMyTasks.SelectedIndex;
        //    bool c= objBL.Status_Change(r);
        //    if (c)
        //        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('The record is saved sucessfully.')", true);
            
        //   //LoadMyTasks();
        //    // update new gridview
      
        //}

      
     }
}