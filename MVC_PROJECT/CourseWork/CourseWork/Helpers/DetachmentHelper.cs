using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseWork.DAL_Models;

namespace CourseWork.Helpers
{
    public class DetachmentHelper
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

        public void CreateDetachment(string Id, string Detachment_name)
        {
            string sqlExpression = "addDetachment";

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

                SqlParameter nameParameter = new SqlParameter
                {
                    ParameterName = "@Detachment_name",
                    Value = Detachment_name
                };

                command.Parameters.Add(nameParameter);
                command.ExecuteScalar();
            }
            CloseConnection();
        }

        public void DeleteDetachment(string Id)
        {
            string sqlExpression = "deleteDetachmentWithId";

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

        public List<Detachment> GetAllDetachments()
        {
            string sqlExpression = "selectAllDetachment";
            List<Detachment> Detachments = new List<Detachment>();
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Detachments.Add(new Detachment
                        {
                            Id = dr.GetValue(0).ToString(),
                            Detachment_name = dr.GetValue(1).ToString(),
                        });
                    }
                }
                return Detachments;
            }
        }

        public Detachment GetDetachmentById(string Id)
        {
            string sqlExpression = "selectDetachmentWithId";
            Detachment detach = null;

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
                        detach = new Detachment
                        {
                            Id = dr.GetValue(0).ToString(),
                            Detachment_name = dr.GetValue(1).ToString()
                        };
                    }
                }
                return detach;
            }

        }

        public Detachment GetDetachmentByName(string Detachment_name)
        {
            string sqlExpression = "selectDetachmentWithName";
            Detachment detach = null;

            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParameter = new SqlParameter
                {
                    ParameterName = "@Detachment_name",
                    Value = Detachment_name
                };
                cmd.Parameters.Add(loginParameter);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        detach = new Detachment
                        {
                            Id = dr.GetValue(0).ToString(),
                            Detachment_name = dr.GetValue(1).ToString()
                        };
                    }
                }
                return detach;
            }

        }

    }
}