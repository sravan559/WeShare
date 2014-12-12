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
    public partial class DateOffSetManager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDateOffset();
            }
        }

        /// <summary>
        /// Saves the offset value entered bu the user to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                BLUsers objBlUsers = new BLUsers();
                int offsetvalue;
                bool isValidNumber = int.TryParse(txtDateOffset.Text.Trim(), out offsetvalue);
                if (isValidNumber && offsetvalue > -1)
                {
                    bool isOffSetSaved = objBlUsers.SaveDateOffset(offsetvalue, Session["UserId"].ToStr());
                    if (!isOffSetSaved)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You cannot set the offset value  such that the effective date is less than today.')", true);
                        //lblMessage.Text = "You cannot set the offset value  such that the effective date is less than today.";
                        return;
                    }
                }
                else
                    lblMessage.Text = "Please enter a valid number.Offset value cannot be a negative value.";
            }
            catch (Exception exception)
            {
                if (!(exception is System.Threading.ThreadAbortException))
                {
                    ExceptionUtility.LogException(exception, "btnSave_Click");
                    Response.Redirect("ErrorPage.aspx");
                }
            }
        }

        /// <summary>
        /// Gets the current value of the date offset set previously in the application
        /// </summary>
        private void LoadDateOffset()
        {
            BLUsers objBlusers = new BLUsers();
            txtDateOffset.Text = objBlusers.GetDateOffset().ToString();
        }
    }
}