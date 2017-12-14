using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using CourseWork.DAL_Models;

namespace CourseWork.Helpers
{
    public class SpeciesHelper
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

        public List<Species> GetAllSpecies()
        {
            string sqlExpression = "selectSpeciesAll";
            List<Species> species = new List<Species>();
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        species.Add(new Species
                        {
                            Id = dr.GetValue(0).ToString(),
                            Suborder = dr.GetValue(3).ToString(),
                            RUS_name= dr.GetValue(1).ToString(),
                            ENG_name = dr.GetValue(2).ToString()

                        });
                    }
                }
                return species;
            }
        }

        public void CreateSpecies(string Id, string Suborder,string RUS_name,string ENG_name)
        {
            string sqlExpression = "addSpecies";

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

                SqlParameter suborderParameter = new SqlParameter
                {
                    ParameterName = "@Suborder",
                    Value = Suborder
                };

                command.Parameters.Add(suborderParameter);

                SqlParameter RusNameParameter = new SqlParameter
                {
                    ParameterName = "@RUS_name",
                    Value = RUS_name
                };

                command.Parameters.Add(RusNameParameter);

                SqlParameter EngNameParameter = new SqlParameter
                {
                    ParameterName = "@ENG_name",
                    Value = ENG_name
                };

                command.Parameters.Add(EngNameParameter);
                command.ExecuteScalar();
            }
            CloseConnection();
        }

        public void DeleteSpecies(string Id)
        {
            string sqlExpression = "deleteSpecies";

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

        public Species GetSpeciesById(string Id)
        {
            string sqlExpression = "selectSpeciesById";
            Species species = null;

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
                        species = new Species
                        {
                            Id = dr.GetValue(0).ToString(),
                            Suborder = dr.GetValue(1).ToString(),
                            RUS_name = dr.GetValue(2).ToString(),
                            ENG_name = dr.GetValue(3).ToString(),
                        };
                    }
                }
                return species;
            }

        }

        public Species GetSpeciesByRusName(string RUS_name)
        {
            string sqlExpression = "selectSpeciesByRUSName";
            Species species = null;

            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter nameParameter = new SqlParameter
                {
                    ParameterName = "@RUS_name",
                    Value = RUS_name
                };
                cmd.Parameters.Add(nameParameter);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        species = new Species
                        {
                            Id = dr.GetValue(0).ToString(),
                            Suborder = dr.GetValue(3).ToString(),
                            RUS_name = dr.GetValue(1).ToString(),
                            ENG_name = dr.GetValue(2).ToString(),
                        };
                    }
                }
                return species;
            }

        }

        public Species GetSpeciesByEngName(string ENG_name)
        {
            string sqlExpression = "selectSpeciesByENGName";
            Species species = null;

            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParameter = new SqlParameter
                {
                    ParameterName = "@ENG_name",
                    Value = ENG_name
                };
                cmd.Parameters.Add(loginParameter);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        species = new Species
                        {
                            Id = dr.GetValue(0).ToString(),
                            Suborder = dr.GetValue(3).ToString(),
                            RUS_name = dr.GetValue(1).ToString(),
                            ENG_name = dr.GetValue(2).ToString(),
                        };
                    }
                }
                return species;
            }

        }

    }
}