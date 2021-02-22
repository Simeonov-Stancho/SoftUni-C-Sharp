using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _07.PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security = true";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                string selectQuery = @"SELECT [Name] FROM Minions";

                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

                List<string> minionsNames = new List<string>();

                using (selectCommand)
                {
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        minionsNames.Add((string)reader["Name"]);
                    }

                    for (int i = 0; i < (minionsNames.Count)/2; i++)
                    {
                        Console.WriteLine(minionsNames[i]);
                        Console.WriteLine(minionsNames[minionsNames.Count-1-i]);
                    }
                }
            }
        }
    }
}
