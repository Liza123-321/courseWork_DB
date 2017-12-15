using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseWork.DAL_Models;

namespace CourseWork.Helpers
{
    public class AnimalHelper
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

        public Animal GetAnimalBySpesies(string Spesies_Id)
        {
            string sqlExpression = "selectAnimalByIdSpesies";
            Animal animals =null;
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParameter = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = Spesies_Id
                };
                cmd.Parameters.Add(loginParameter);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        animals = new Animal
                        {
                            Id = dr.GetValue(0).ToString(),
                            Species = dr.GetValue(3).ToString(),
                            Descript = dr.GetValue(1).ToString(),
                            PhotoUrl = dr.GetValue(2).ToString(),
                            Lineament = dr.GetValue(3).ToString(),
                            Animal_name = dr.GetValue(4).ToString(),
                        };
                    }
                }
                return animals;
            }
        }
    }
}