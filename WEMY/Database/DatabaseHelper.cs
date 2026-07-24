using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WEMY.Database
{
    public class DatabaseHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(
                ConfigurationManager.ConnectionStrings["WEMYConnection"].ConnectionString);
        }
    }
}