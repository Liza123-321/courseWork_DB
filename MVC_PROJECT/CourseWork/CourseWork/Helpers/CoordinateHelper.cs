using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CourseWork.Helpers
{
    public class CoordinateHelper
    {
        private SqlConnection connect;
        public const string ConnectionString = @"Data Source=.;Initial Catalog=ReliseCourse;Integrated Security=True";

        public void OpenConnection(string connectionSting)
        {
            connect = new SqlConnection(connectionSting);
            connect.Open();
        }

        public void CloseConnection()
        {
            connect.Close();
        }
    }
}