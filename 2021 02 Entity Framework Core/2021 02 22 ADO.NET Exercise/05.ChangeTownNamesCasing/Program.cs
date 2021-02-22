using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.;Database={0};Integrated Security=true";

            SqlConnection connection = new SqlConnection(string.Format(connectionString, "MinionsDB"));

            string country = Console.ReadLine();

            using (connection)
            {
                connection.Open();

                string changeCityNames = "UPDATE Towns SET Name = UPPER(Name)WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
                SqlCommand command = new SqlCommand(changeCityNames, connection);
                command.Parameters.AddWithValue("@countryName", country);

                using (command)
                {
                    int affectedRows = command.ExecuteNonQuery();

                    if (affectedRows == 0)
                    {
                        Console.WriteLine("No town names were affected.");
                    }

                    else
                    {
                        Console.WriteLine($"{affectedRows} town names were affected.");

                        string findAllCityNames = "SELECT t.Name FROM Towns as t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.Name = @countryName";
                        command = new SqlCommand(findAllCityNames, connection);
                        command.Parameters.AddWithValue("@countryName", country);

                        using (command)
                        {
                            SqlDataReader reader = command.ExecuteReader();
                            List<string> cityNames = new List<string>();
                            while (reader.Read())
                            {
                                cityNames.Add((string)reader["Name"]);
                            }

                            Console.WriteLine($"[{string.Join(", ", cityNames)}]");
                        }
                    }
                }
            }
        }
    }
}

