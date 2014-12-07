using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WeShare.DataAccess
{
    public class DAHelper
    {
        protected SqlConnection objSqlConnection = null;
        protected SqlCommand objSqlCommand = null;

        /// <summary>
        /// Returns the connection string from the web config file for the WeShare application
        /// </summary>
        /// <returns></returns>
        protected static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["WeShareConnectionString"].ConnectionString;
           // return "Data Source=TERMINATOR;Initial Catalog=WeShare;User ID=sa;Password=Sandeepgarimella220";
        }

        
        protected void CloseConnection()
        {
            if (objSqlConnection != null && objSqlConnection.State == ConnectionState.Open)
                objSqlConnection.Close();
        }

    }
}
