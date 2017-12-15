using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseWork.DAL_Models;

namespace CourseWork.Helpers
{
    public class MethodHelper
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

        public void CreateMethod(string Id, string Descript, string Units)
        {
            string sqlExpression = "addMethod";

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

                SqlParameter descParameter = new SqlParameter
                {
                    ParameterName = "@Descript",
                    Value = Descript
                };

                command.Parameters.Add(descParameter);
                SqlParameter unitsParameter = new SqlParameter
                {
                    ParameterName = "@Units",
                    Value = Units
                };

                command.Parameters.Add(unitsParameter);
                command.ExecuteScalar();
            }
            CloseConnection();
        }

        public void DeleteMethod(string Id)
        {
            string sqlExpression = "deleteMethod";

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
                cmd.ExecuteScalar();
            }
        }

        public List<Method> GetAllMethods()
        {
            string sqlExpression = "selectAllMethod";
            List<Method> methods = new List<Method>();
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        methods.Add(new Method
                        {
                            Id = dr.GetValue(0).ToString(),
                            Descript = dr.GetValue(1).ToString(),
                            Units = dr.GetValue(2).ToString(),
                        });
                    }
                }
                return methods;
            }
        }

        public Method GetMethodById(string Id)
        {
            string sqlExpression = "selectMethodById";
            Method method = null;

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
                        method = new Method
                        {
                            Id = dr.GetValue(0).ToString(),
                            Descript = dr.GetValue(1).ToString(),
                            Units = dr.GetValue(2).ToString(),
                        };
                    }
                }
                return method;
            }

        }
    }
}