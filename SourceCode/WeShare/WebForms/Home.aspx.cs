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
            }
        }

        private void LoadMyTasks()
        {
            BLTasks objBlTasks = new BLTasks();
            List<TaskAssignmentInfo> listTaskInfo = objBlTasks.GetUserTasksByMailId(Session["UserId"].ToString());
            gvMyTasks.DataSource = listTaskInfo;
            gvMyTasks.DataBind();
        }
    }
}