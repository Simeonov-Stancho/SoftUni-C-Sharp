using Microsoft.Data.SqlClient;
using System;

namespace _02.VillainNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.; Database={0}; Integrated Security=true";

            SqlConnection sqlConnection = new SqlConnection(string.Format(connectionString, "MinionsDB"));

            using (sqlConnection)
            {
                sqlConnection.Open();

                //for more result > 0
                string selectQuery =
                    @"SELECT v.Name, COUNT(mv.MinionId) AS MinionsCount
                                    FROM Villains as v
                                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                    GROUP BY v.Id, v.Name
                                    HAVING COUNT(mv.MinionId) > 3
                                    ORDER BY COUNT(mv.MinionId) DESC";

                

                SqlCommand selectCommand = new SqlCommand(selectQuery, sqlConnection);

                using (selectCommand)
                {
                    try
                    {
                        SqlDataReader reader = selectCommand.ExecuteReader();

                        using (reader)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                            }
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
