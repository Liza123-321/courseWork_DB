using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseWork.DAL_Models;

namespace CourseWork.Helpers
{
    public class RegistrationAnimalHelper
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

        public void CreateRegAnimal(string Id, string Animal, string Registration_author, string Coordinates, string Method)
        {
            string sqlExpression = "addRegistration_animal";

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
                SqlParameter animalParameter = new SqlParameter
                {
                    ParameterName = "@Animal",
                    Value = Animal
                };

                command.Parameters.Add(animalParameter);
                SqlParameter authorParameter = new SqlParameter
                {
                    ParameterName = "@Registration_author",
                    Value = Registration_author
                };

                command.Parameters.Add(authorParameter);
                SqlParameter coordParameter = new SqlParameter
                {
                    ParameterName = "@Coordinates",
                    Value = Coordinates
                };

                command.Parameters.Add(coordParameter);
                SqlParameter methodParameter = new SqlParameter
                {
                    ParameterName = "@Method",
                    Value = Method
                };

                command.Parameters.Add(methodParameter);
                command.ExecuteScalar();
            }
            CloseConnection();
        }

        public void DeleteRegAnimal(string id)
        {
            string sqlExpression = "deleteRegistration_animal";

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

        public List<FullReg_animal> GetAllReg_animals()
        {
            string sqlExpression = "selectAllReg_animal";
            List<FullReg_animal> reg_animal= new List<FullReg_animal>();
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        reg_animal.Add(new FullReg_animal
                        {
                            Id = dr.GetValue(0).ToString(),
                            Animal_name = dr.GetValue(1).ToString(),
                            Author_name = dr.GetValue(2).ToString(),
                            Method_descript = dr.GetValue(3).ToString(),
                            Coord_type = dr.GetValue(4).ToString(),
                            Coord_cords = dr.GetValue(5).ToString(),
                        });
                    }
                }
                return reg_animal;
            }
        }

        public FullReg_animal GetRegAnimalById(string Id)
        {
            string sqlExpression = "selectReg_animalById";
            FullReg_animal reg_animal = null;

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
                        reg_animal = new FullReg_animal
                        {
                            Id = dr.GetValue(0).ToString(),
                            Animal_name = dr.GetValue(1).ToString(),
                            Author_name = dr.GetValue(2).ToString(),
                            Method_descript = dr.GetValue(3).ToString(),
                            Coord_type = dr.GetValue(4).ToString(),
                            Coord_cords = dr.GetValue(5).ToString(),
                        };
                    }
                }
                return reg_animal;
            }

        }

        public Registration_animal GetRegAnimalByAuthorId(string Id)
        {
            string sqlExpression = "selectRegister_animalByAnimalId";
            Registration_animal reg_animal = null;

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
                        reg_animal = new Registration_animal
                        {
                            Id = dr.GetValue(0).ToString(),
                            Animal = dr.GetValue(1).ToString(),
                            Registration_author = dr.GetValue(2).ToString(),
                            Coordibates = dr.GetValue(3).ToString(),
                            Method = dr.GetValue(4).ToString(),
                        };
                    }
                }
                return reg_animal;
            }

        }

        public Registration_animal GetRegAnimalByMethodId(string Id)
        {
            string sqlExpression = "selectRegister_animalByMethodId";
            Registration_animal reg_animal = null;

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
                        reg_animal = new Registration_animal
                        {
                            Id = dr.GetValue(0).ToString(),
                            Animal = dr.GetValue(1).ToString(),
                            Registration_author = dr.GetValue(2).ToString(),
                            Coordibates = dr.GetValue(3).ToString(),
                            Method = dr.GetValue(4).ToString(),
                        };
                    }
                }
                return reg_animal;
            }

        }

        public Registration_animal GetRegAnimalByCoordId(string Id)
        {
            string sqlExpression = "selectRegistration_animalByCoordId";
            Registration_animal reg_animal = null;

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
                        reg_animal = new Registration_animal
                        {
                            Id = dr.GetValue(0).ToString(),
                            Animal = dr.GetValue(1).ToString(),
                            Registration_author = dr.GetValue(2).ToString(),
                            Coordibates = dr.GetValue(3).ToString(),
                            Method = dr.GetValue(4).ToString(),
                        };
                    }
                }
                return reg_animal;
            }

        }

        public Registration_animal GetRegAnimalByReg_authorId(string Id)
        {
            string sqlExpression = "selectRegister_animalByReg_AuthorId";
            Registration_animal reg_animal = null;

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
                        reg_animal = new Registration_animal
                        {
                            Id = dr.GetValue(0).ToString(),
                            Animal = dr.GetValue(1).ToString(),
                            Registration_author = dr.GetValue(2).ToString(),
                            Coordibates = dr.GetValue(3).ToString(),
                            Method = dr.GetValue(4).ToString(),
                        };
                    }
                }
                return reg_animal;
            }

        }

    }
}