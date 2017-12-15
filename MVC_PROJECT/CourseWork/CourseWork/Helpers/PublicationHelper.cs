using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseWork.DAL_Models;

namespace CourseWork.Helpers
{
    public class PublicationHelper
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

        public void CreatePublication(string Id, string Author, DateTime Publication_date, string link)
        {
            string sqlExpression = "addPublication";

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
                    ParameterName = "@Author",
                    Value = Author
                };
                command.Parameters.Add(nameParameter);
                SqlParameter dateParameter = new SqlParameter
                {
                    ParameterName = "@Publication_date",
                    Value = Publication_date
                };
                command.Parameters.Add(dateParameter);
                SqlParameter linkParameter = new SqlParameter
                {
                    ParameterName = "@link",
                    Value = link
                };
                command.Parameters.Add(linkParameter);

                command.ExecuteScalar();
            }
            CloseConnection();
        }

        public void DeletePublication(string Id)
        {
            string sqlExpression = "deletePublication";

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

        public List<Publication> GetAllEcosystems()
        {
            string sqlExpression = "selectAllPublication";
            List<Publication> publication = new List<Publication>();
            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        publication.Add(new Publication
                        {
                            Id = dr.GetValue(0).ToString(),
                            Author = dr.GetValue(1).ToString(),
                            Publication_date = Convert.ToDateTime(dr.GetValue(2).ToString()),
                            link = dr.GetValue(3).ToString(),
                        });
                    }
                }
                return publication;
            }
        }

        public Publication GetPublicationById(string Id)
        {
            string sqlExpression = "selectPublicationById";
            Publication publication = null;

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
                        publication = new Publication
                        {
                            Id = dr.GetValue(0).ToString(),
                            Author = dr.GetValue(1).ToString(),
                            Publication_date = Convert.ToDateTime(dr.GetValue(2).ToString()),
                            link = dr.GetValue(3).ToString(),
                        };
                    }
                }
                return publication;
            }

        }

        public Publication GetPublicationByLink(string link)
        {
            string sqlExpression = "selectPublicationByLink";
            Publication publication = null;

            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParameter = new SqlParameter
                {
                    ParameterName = "@link",
                    Value = link
                };
                cmd.Parameters.Add(loginParameter);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        publication = new Publication
                        {
                            Id = dr.GetValue(0).ToString(),
                            Author = dr.GetValue(1).ToString(),
                            Publication_date = Convert.ToDateTime(dr.GetValue(2).ToString()),
                            link = dr.GetValue(3).ToString(),
                        };
                    }
                }
                return publication;
            }

        }

        public Publication GetPublicationAfterDate(string Publication_date)
        {
            string sqlExpression = "selectPublicationAfterDate";
            Publication publication = null;

            OpenConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sqlExpression, connect))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter loginParameter = new SqlParameter
                {
                    ParameterName = "@Publication_date",
                    Value = Publication_date
                };
                cmd.Parameters.Add(loginParameter);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        publication = new Publication
                        {
                            Id = dr.GetValue(0).ToString(),
                            Author = dr.GetValue(1).ToString(),
                            Publication_date = Convert.ToDateTime(dr.GetValue(2).ToString()),
                            link = dr.GetValue(3).ToString(),
                        };
                    }
                }
                return publication;
            }

        }

        public Publication GetEcosystemByAuthorId(string Id)
        {
            string sqlExpression = "selectPublicationByAuthorId";
            Publication publication= null;
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
                        publication = new Publication
                        {
                            Id = dr.GetValue(0).ToString(),
                            Author = dr.GetValue(1).ToString(),
                            Publication_date = Convert.ToDateTime(dr.GetValue(2).ToString()),
                            link = dr.GetValue(3).ToString(),
                        };
                    }
                }
                return publication;
            }
        }
    }
}