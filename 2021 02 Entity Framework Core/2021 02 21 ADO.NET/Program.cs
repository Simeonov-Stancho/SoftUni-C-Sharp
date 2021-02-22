using System;
using Microsoft.Data.SqlClient;

namespace CSharpDbDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection
                        ("Server=.;Integrated Security=true;Database=SoftUni"))
            {
                connection.Open();

                string query = "SELECT (*) FROM Employees";
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                sqlCommand.ExecuteNonQuery();
            }


        }
    }
}
