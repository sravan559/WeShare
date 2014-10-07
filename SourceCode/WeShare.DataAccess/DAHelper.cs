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
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["WeShareConnectionString"].ConnectionString;
        }

        public static void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}
