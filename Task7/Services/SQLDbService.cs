using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Task7.Models;
using Task7.Statics;

namespace Task7.Services
{
    public class SQLDbService : IDbService
    {
        public Student GetStudent(string password)
        {
            using (SqlConnection connection = new SqlConnection(Static.CONNECTION_STRING))
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = @"select FirstName, LastName 
                                        from Student 
                                        where IndexNumber=@index";

                command.Parameters.AddWithValue("index",password);
                connection.Open();
                var query = command.ExecuteReader();
                Student student=null;
                if (query.Read())
                {
                    student = new Student();
                    student.FirstName = query["FirstName"].ToString();
                    student.LastName = query["LastName"].ToString();
                }

                return student;
            }
        }
    }
}
