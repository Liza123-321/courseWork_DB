using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseWork.DAL_Models;

namespace CourseWork.Helpers
{
    public class AuthorHelper
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

        public bool CreateAuthor(string Id, string Author_name,string pass)
        {
            string sqlExpression = "addAuthor";

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
                    ParameterName = "@Author_name",
                    Value = Author_name
                };

                command.Parameters.Add(nameParameter);
                SqlParameter passParameter = new SqlParameter
                {
                    ParameterName = "@Pass",
                    Value = pass
                };

                command.Parameters.Add(passParameter);
                command.ExecuteScalar();
            }
            CloseConnection();
            return true;
        }

        public void DeleteAuthor(string Id)
        {
            string sqlExpression = "deleteAuthor";

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

        public List<Author> GetAllAuthors()
        {
            string sqlExpression = "selectAllAuthor";
            List<Author> Authors = new List<Author>();
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Authors.Add(new Author
                        {
                            Id = dr.GetValue(0).ToString(),
                            Author_name = dr.GetValue(1).ToString(),
                            Pass = dr.GetValue(2).ToString(),
                        });
                    }
                }
                return Authors;
            }
        }

        public Author GetAuthorById(string Id)
        {
            string sqlExpression = "selectAuthorId";
            Author author = null;

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
                        author = new Author
                        {
                            Id = dr.GetValue(0).ToString(),
                            Author_name = dr.GetValue(1).ToString(),
                            Pass = dr.GetValue(2).ToString(),

                        };
                    }
                }
                return author;
            }

        }

        public Author AuthorByName(string Author_name)
        {
            string sqlExpression = "selectAuthorByName";
            Author author = null;

            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParameter = new SqlParameter
                {
                    ParameterName = "@Author_name",
                    Value = Author_name
                };
                cmd.Parameters.Add(loginParameter);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        author = new Author
                        {
                            Id = dr.GetValue(0).ToString(),
                            Author_name = dr.GetValue(1).ToString(),
                            Pass = dr.GetValue(2).ToString(),
                        };
                    }
                }
                return author;
            }

        }
    }
}