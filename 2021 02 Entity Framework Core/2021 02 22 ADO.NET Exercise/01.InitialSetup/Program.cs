using Microsoft.Data.SqlClient;
using System;

namespace _01.InitialSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlConnectionString = "Server=.;Database={0};Integrated Security=true";

            var sqlConnection = new SqlConnection(string.Format(sqlConnectionString, "master"));

            using (sqlConnection)
            {
                sqlConnection.Open();

                string queryCreateDB = "CREATE DATABASE MinionsDB";

                try
                {
                    SqlCommand createDB = new SqlCommand(queryCreateDB, sqlConnection);
                    createDB.ExecuteNonQuery();

                    Console.WriteLine("Database created succsesfully!");
                }

                catch (Exception ex)
                {
                    Console.WriteLine("There was error:");
                    Console.WriteLine(ex.Message);
                }
            }

            sqlConnection = new SqlConnection(string.Format(sqlConnectionString, "MinionsDB"));

            using (sqlConnection)
            {
                sqlConnection.Open();

                string queryCreateTables =
                   @"CREATE TABLE Countries(Id INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50))
                    CREATE TABLE Towns(	Id INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))
                    CREATE TABLE Minions( Id INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50),	Age INT, 	TownId INT FOREIGN KEY REFERENCES Towns(Id))
                    CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY,  [Name] VARCHAR(50))
                    CREATE TABLE Villains(Id INT PRIMARY KEY IDENTITY,    [Name] VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))
                    CREATE TABLE MinionsVillains(MinionId INT FOREIGN KEY REFERENCES Minions(Id), VillainId INT FOREIGN KEY REFERENCES Villains(Id)   CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId))";

                try
                {
                    SqlCommand createTables = new SqlCommand(queryCreateTables, sqlConnection);
                    createTables.ExecuteNonQuery();

                    Console.WriteLine("Tables was created succsesfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was error:");
                    Console.WriteLine(ex.Message);
                }

                string queryInsertTables =
                    @"INSERT INTO Countries([Name]) VALUES ('Bulgaria'), ('Romania'), ('Turkey'), ('Greece'), ('Serbia')
                    INSERT INTO Towns([Name], CountryCode) VALUES('Varna', 1), ('Bucharest', 2), ('Instanbul', 3), ('Athens', 4), ('Nis', 5)
                    INSERT INTO Minions([Name], Age, TownId) VALUES('Dimitrichko', 5, 1), ('Sergiu', 25, 2), ('AliRaza', 55, 3), ('George', 27, 4), ('Dragan', 33, 5), ('Pesho', 25, 1), ('Mindru', 29, 2), ('Ferhunde', 22, 3), ('Agape', 27, 4), ('Zoran', 33, 5)
                    INSERT INTO EvilnessFactors(Name) VALUES('Super good'), ('Good'), ('Bad'), ('Evil'), ('Super evil')
                    INSERT INTO Villains([Name], EvilnessFactorId) VALUES('Steel', 1), ('Dr. Manhattan', 2), ('Black Widow', 3), ('Rorschach', 4), ('Galactus', 5), ('Loki', 1), ('Gambit', 2)
                    INSERT INTO MinionsVillains(MinionId, VillainId) VALUES(1, 2), (2, 3), (3, 3), (4, 4), (5, 2), (6, 5), (7, 6), (8, 7), (9, 3), (10, 3)";

                try
                {
                    SqlCommand insertTables = new SqlCommand(queryInsertTables, sqlConnection);
                    int rowsAffected = insertTables.ExecuteNonQuery();

                    Console.WriteLine($"Total rows affected: {rowsAffected}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error inserting data into tables!");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
