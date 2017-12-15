using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseWork.DAL_Models;

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

        public void CreateCoordinates(string Id, string Type,string Adress,string Latitude,string Longitude)
        {
            string sqlExpression = "addCoordinates";

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
                SqlParameter typeParameter = new SqlParameter
                {
                    ParameterName = "@Type",
                    Value = Type
                };

                command.Parameters.Add(typeParameter);
                SqlParameter addrParameter = new SqlParameter
                {
                    ParameterName = "@Adress",
                    Value = Adress
                };

                command.Parameters.Add(addrParameter);
                SqlParameter latParameter = new SqlParameter
                {
                    ParameterName = "@Latitude",
                    Value = Latitude
                };

                command.Parameters.Add(latParameter);
                SqlParameter longParameter = new SqlParameter
                {
                    ParameterName = "@Longitude",
                    Value = Longitude
                };

                command.Parameters.Add(longParameter);
                command.ExecuteScalar();
            }
            CloseConnection();
        }

        public void DeleteCoordinate(string Id)
        {
            string sqlExpression = "deleteCoordinate";

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

        public List<Coordinates> GetAllCoordinates()
        {
            string sqlExpression = "selectAllCoordinates";
            List<Coordinates> coords = new List<Coordinates>();
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        coords.Add(new Coordinates
                        {
                            Id = dr.GetValue(0).ToString(),
                           GeoJson = dr.GetValue(1).ToString(),
                        });
                    }
                }
                return coords;
            }
        }

        public List<CoordinatesRe> GetAllCoordinatesRe()
        {
            string sqlExpression = "selectAllCoordinatesRe";
            List<CoordinatesRe> coords = new List<CoordinatesRe>();
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        coords.Add(new CoordinatesRe
                        {
                            Id = dr.GetValue(0).ToString(),
                            Type = dr.GetValue(1).ToString(),
                            Coord = dr.GetValue(2).ToString(),
                        });
                    }
                }
                return coords;
            }
        }

        public CoordinatesRe GetCoordinateById(string Id)
        {
            string sqlExpression = "selectCoordinatesById";
            CoordinatesRe coord = null;

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
                        coord = new CoordinatesRe
                        {
                            Id = dr.GetValue(0).ToString(),
                            Type = dr.GetValue(1).ToString(),
                            Coord = dr.GetValue(2).ToString(),
                        };
                    }
                }
                return coord;
            }

        }

    }
}