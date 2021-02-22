using System;
using Microsoft.Data.SqlClient;

namespace _03.MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose a villain ID:");
            int villainID = int.Parse(Console.ReadLine());

            string connectionString = "Server=.; Database={0};Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(string.Format(connectionString, "MinionsDB"));

            using (sqlConnection)
            {
                sqlConnection.Open();

                string selectQuery = @"SELECT [Name] FROM Villains WHERE Id = @villainID";
                SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);
                selectCommand.Parameters.AddWithValue("@villainID", villainID);

                using (selectCommand)
                {
                    try
                    {
                        string villainName = (string)selectCommand.ExecuteScalar();

                        if (villainName != null)
                        {
                            Console.WriteLine($"Villain: {villainName}");
                        }

                        else
                        {
                            Console.WriteLine($"No villain with ID {villainID} exists in the database.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                selectQuery = @"SELECT ROW_NUMBER() 
                                       OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                    WHERE mv.VillainId = @villainID
                                    ORDER BY m.Name";

                selectCommand = new SqlCommand(selectQuery, sqlConnection);
                selectCommand.Parameters.AddWithValue("@villainID", villainID);

                using (selectCommand)
                {
                    try
                    {
                        int rowNumber = 1;

                        SqlDataReader reader = selectCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            string minionName = (string)reader["Name"];
                            int age = (int)reader["Age"];

                            Console.WriteLine($"{rowNumber}. {minionName} {age}");

                            rowNumber++;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}