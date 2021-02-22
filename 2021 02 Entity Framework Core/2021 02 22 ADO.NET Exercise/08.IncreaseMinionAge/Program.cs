using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> minionsID = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            string connectionString = "Server=.;Database=MinionsDB;Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                string updateQuery = @"UPDATE Minions
                                         SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)),
	                                     Age += 1
                                        WHERE Id = @Id";

                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);

                using (updateCommand)
                {
                    for (int i = 0; i < minionsID.Count; i++)
                    {
                        updateCommand.Parameters.AddWithValue("@Id", minionsID[i]);
                        updateCommand.ExecuteNonQuery();
                        updateCommand.Parameters.Clear();
                    }
                }

                string selectQuery = @"SELECT Name, Age FROM Minions";

                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

                using (selectCommand)
                {
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{(string)reader["Name"]} {(int)reader["Age"]}");
                    }
                }
            }
        }
    }
}
