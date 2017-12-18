using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseWork.DAL_Models;

namespace CourseWork.Helpers
{
    public class RegisterationAuthorHelper
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



        public void CreateReg_author(string Id, DateTime Reg_date, string Author)
        {
            string sqlExpression = "addRegistration_author";

            OpenConnection(ConnectionString);
            using (SqlCommand command = new SqlCommand(sqlExpression, connect))
            {
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idParameter = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = Id
                };

                command.Parameters.Add(idParameter);
                SqlParameter dateParameter = new SqlParameter
                {
                    ParameterName = "@Reg_date",
                    Value = Reg_date
                };

                command.Parameters.Add(dateParameter);
                SqlParameter authorParameter = new SqlParameter
                {
                    ParameterName = "@Author",
                    Value = Author
                };
                command.Parameters.Add(authorParameter);
                command.ExecuteScalar();
            }
            CloseConnection();
        }

        public void DeleteReg_author(string id)
        {
            string sqlExpression = "deleteRegistration_author";

            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParameter = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id
                };
                cmd.Parameters.Add(loginParameter);
                cmd.ExecuteScalar();
            }
        }

        public List<Registration_author> GetAllReg_author()
        {
            string sqlExpression = "selectAllReg_author";
            List<Registration_author> regs_author = new List<Registration_author>();
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        regs_author.Add(new Registration_author
                        {
                            Id = dr.GetValue(0).ToString(),
                            Reg_date = Convert.ToDateTime(dr.GetValue(1).ToString()),
                            Author = dr.GetValue(2).ToString(),

                        });
                    }
                }
                return regs_author;
            }
        }

        public Registration_author GetReg_authorById(string Id)
        {
            string sqlExpression = "selectReg_authorById";
            Registration_author reg_author = null;

            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParameter = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = Id
                };
                cmd.Parameters.Add(loginParameter);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        reg_author = new Registration_author
                        {
                            Id = dr.GetValue(0).ToString(),
                            Reg_date = Convert.ToDateTime(dr.GetValue(1).ToString()),
                            Author = dr.GetValue(2).ToString(),
                        };
                    }
                }
                return reg_author;
            }

        }

        public Registration_author GetReg_authorByAuthorId(string Id)
        {
            string sqlExpression = "selectReg_authorByAythorName";
            Registration_author reg_author = null;

            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParameter = new SqlParameter
                {
                    ParameterName = "@Author",
                    Value = Id
                };
                cmd.Parameters.Add(loginParameter);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        reg_author = new Registration_author
                        {
                            Id = dr.GetValue(0).ToString(),
                            Reg_date = Convert.ToDateTime(dr.GetValue(1).ToString()),
                            Author = dr.GetValue(2).ToString(),
                        };
                    }
                }
                return reg_author;
            }

        }


    }
}