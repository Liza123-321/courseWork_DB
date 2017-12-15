using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseWork.DAL_Models;

namespace CourseWork.Helpers
{
    public class EcosystemHelper
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

        public void CreateEcosystem(string Id, string Ecosystem_name,string Biotope,string Coordinates)
        {
            string sqlExpression = "addEcosystem";

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
                    ParameterName = "@Ecosystem_name",
                    Value = Ecosystem_name
                };
                command.Parameters.Add(nameParameter);
                SqlParameter bitopeParameter = new SqlParameter
                {
                    ParameterName = "@Coordinates",
                    Value = Coordinates
                };
                command.Parameters.Add(bitopeParameter);
                SqlParameter coordParameter = new SqlParameter
                {
                    ParameterName = "@Biotope",
                    Value = Biotope
                };
                command.Parameters.Add(coordParameter);

                command.ExecuteScalar();
            }
            CloseConnection();
        }

        public void DeleteEcosystem(string Id)
        {
            string sqlExpression = "deleteEcosystem";

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

        public List<Ecosystem> GetAllEcosystems()
        {
            string sqlExpression = "selectAllEcosystem";
            List<Ecosystem> ecosystems = new List<Ecosystem>();
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ecosystems.Add(new Ecosystem
                        {
                            Id = dr.GetValue(0).ToString(),
                           Ecosystem_name = dr.GetValue(1).ToString(),
                           Biotope = dr.GetValue(2).ToString(),
                           Coordinates = dr.GetValue(3).ToString(),
                        });
                    }
                }
                return ecosystems;
            }
        }

        public Ecosystem GetEcosystemById(string Id)
        {
            string sqlExpression = "selectEcosystemById";
            Ecosystem ecosystem = null;

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
                        ecosystem = new Ecosystem
                        {
                            Id = dr.GetValue(0).ToString(),
                            Ecosystem_name = dr.GetValue(1).ToString(),
                            Biotope = dr.GetValue(2).ToString(),
                            Coordinates = dr.GetValue(3).ToString(),
                        };
                    }
                }
                return ecosystem;
            }

        }

        public Ecosystem GetEcosystemByName(string Ecosystem_name)
        {
            string sqlExpression = "selectEcosystemByName";
            Ecosystem ecosystem = null;

            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParameter = new SqlParameter
                {
                    ParameterName = "@Ecosystem_name",
                    Value = Ecosystem_name
                };
                cmd.Parameters.Add(loginParameter);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ecosystem = new Ecosystem
                        {
                            Id = dr.GetValue(0).ToString(),
                            Ecosystem_name = dr.GetValue(1).ToString(),
                            Biotope = dr.GetValue(2).ToString(),
                            Coordinates = dr.GetValue(3).ToString(),
                        };
                    }
                }
                return ecosystem;
            }

        }
    }
}