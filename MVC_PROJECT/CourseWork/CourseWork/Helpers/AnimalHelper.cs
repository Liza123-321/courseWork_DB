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


        public void CreateAnimal(string Id, string Species,string Descript, string PhotoUrl,string Lineament)
        {
            string sqlExpression = "addAnimal";

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
                SqlParameter speciesParameter = new SqlParameter
                {
                    ParameterName = "@Species",
                    Value = Species
                };

                command.Parameters.Add(speciesParameter);
                SqlParameter descParameter = new SqlParameter
                {
                    ParameterName = "@Descript",
                    Value = Descript
                };

                command.Parameters.Add(descParameter);
                SqlParameter photoParameter = new SqlParameter
                {
                    ParameterName = "@PhotoUrl",
                    Value = PhotoUrl
                };

                command.Parameters.Add(photoParameter);
                SqlParameter lineamentParameter = new SqlParameter
                {
                    ParameterName = "@Lineament",
                    Value = Lineament
                };

                command.Parameters.Add(lineamentParameter);
                command.ExecuteScalar();
            }
            CloseConnection();
        }

        public void DeleteAnimal(string Id)
        {
            string sqlExpression = "deleteAnimal";

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

        public List<Animal> GetAllAnimals()
        {
            string sqlExpression = "selectAllAnimal";
            List<Animal> Animals = new List<Animal>();
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Animals.Add(new Animal
                        {
                            Id = dr.GetValue(0).ToString(),
                            Species = dr.GetValue(1).ToString(),
                            Descript = dr.GetValue(2).ToString(),
                            PhotoUrl = dr.GetValue(3).ToString(),
                            Lineament = dr.GetValue(4).ToString(),
                        });
                    }
                }
                return Animals;
            }
        }

        public Animal GetAnimalById(string Id)
        {
            string sqlExpression = "selectAnimalById";
            Animal animal = null;

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
                        animal = new Animal
                        {
                            Id = dr.GetValue(0).ToString(),
                            Species = dr.GetValue(1).ToString(),
                            Descript = dr.GetValue(2).ToString(),
                            PhotoUrl = dr.GetValue(3).ToString(),
                            Lineament = dr.GetValue(4).ToString(),
                        };
                    }
                }
                return animal;
            }

        }

        public Animal GetAnimalByName(string Id)
        {
            string sqlExpression = "selectAnimalByName";
            Animal animal = null;

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
                        animal = new Animal
                        {
                            Id = dr.GetValue(0).ToString(),
                            Species = dr.GetValue(1).ToString(),
                            Descript = dr.GetValue(2).ToString(),
                            PhotoUrl = dr.GetValue(3).ToString(),
                            Lineament = dr.GetValue(4).ToString(),
                        };
                    }
                }
                return animal;
            }

        }
    }
}