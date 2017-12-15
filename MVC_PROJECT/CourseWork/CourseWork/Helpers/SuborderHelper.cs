using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseWork.DAL_Models;

namespace CourseWork.Helpers
{
    public class SuborderHelper
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

        public bool CreateSuborder(string Id, string Detachment, string Suborder_name,int count_genus)
        {
            string sqlExpression = "addSuborder";

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
                    ParameterName = "@Detachment",
                    Value = Detachment
                };

                command.Parameters.Add(nameParameter);
                SqlParameter suborderParameter = new SqlParameter
                {
                    ParameterName = "@Suborder_name",
                    Value = Suborder_name
                };

                command.Parameters.Add(suborderParameter);
                SqlParameter countParameter = new SqlParameter
                {
                    ParameterName = "@Count_genus",
                    Value = count_genus
                };

                command.Parameters.Add(countParameter);
                command.ExecuteScalar();
            }
            CloseConnection();
            return true;
        }

        public void DeleteSuborder(string Id)
        {
            string sqlExpression = "deleteSuborder";

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

        public List<Suborder> GetAllSuborder()
        {
            string sqlExpression = "selectSuborderAll";
            List<Suborder> Suborders = new List<Suborder>();
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Suborders.Add(new Suborder
                        {
                            Id = dr.GetValue(0).ToString(),
                            Detachment = dr.GetValue(1).ToString(),
                            Suborder_name = dr.GetValue(2).ToString(),
                            Count_genus = dr.GetValue(3).ToString(),
                        });
                    }
                }
                return Suborders;
            }
        }

        public Suborder GetSuborderById(string Id)
        {
            string sqlExpression = "selectSuborderById";
            Suborder suborder = null;

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
                        suborder = new Suborder
                        {
                            Id = dr.GetValue(0).ToString(),
                            Detachment = dr.GetValue(1).ToString(),
                            Suborder_name = dr.GetValue(2).ToString(),
                            Count_genus = dr.GetValue(3).ToString(),

                        };
                    }
                }
                return suborder;
            }

        }

        public Suborder GetSuborderByName(string Suborder_name)
        {
            string sqlExpression = "selectSuborderByName";
            Suborder suborder = null;

            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParameter = new SqlParameter
                {
                    ParameterName = "@Suborder_name",
                    Value = Suborder_name
                };
                cmd.Parameters.Add(loginParameter);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        suborder = new Suborder
                        {
                            Id = dr.GetValue(0).ToString(),
                            Detachment = dr.GetValue(1).ToString(),
                            Suborder_name = dr.GetValue(2).ToString(),
                            Count_genus = dr.GetValue(3).ToString(),
                        };
                    }
                }
                return suborder;
            }

        }

        public Suborder GetSuborderByDetach(string Detach_Id)
        {
            string sqlExpression = "selectSuborderByDetachId";
            Suborder suborder = null;
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
   
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParameter = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = Detach_Id
                };
                cmd.Parameters.Add(loginParameter);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        suborder = new Suborder
                        {
                            Id = dr.GetValue(0).ToString(),
                            Detachment = dr.GetValue(1).ToString(),
                            Suborder_name = dr.GetValue(2).ToString(),
                            Count_genus = dr.GetValue(3).ToString(),
                        };
                    }
                }
                return suborder;
            }
        }
    }
}