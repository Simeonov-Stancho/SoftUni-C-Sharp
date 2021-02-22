using System;
using Microsoft.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                string procedureQuery = @"CREATE PROC usp_GetOlder(@id INT)
                                            AS
                                            UPDATE Minions
                                            SET Age +=1
                                            WHERE Id = @id";

                SqlCommand command = new SqlCommand(procedureQuery, connection);

                using (command)
                {
                    command.ExecuteNonQuery();
                }

                int id = int.Parse(Console.ReadLine());
                string procedureExecQuery = @"EXEC usp_GetOlder @id";
                command = new SqlCommand(procedureExecQuery, connection);
                command.Parameters.AddWithValue("@id", id);

                using (command)
                {
                    command.ExecuteNonQuery();
                }

                string selectQuery = @"SELECT Name, Age FROM Minions WHERE Id = @id";
                command = new SqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@id", id);

                using (command)
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{(string)reader["Name"]} - {(int)reader["Age"]} years old");
                    }
                }
            }
        }
    }
}
