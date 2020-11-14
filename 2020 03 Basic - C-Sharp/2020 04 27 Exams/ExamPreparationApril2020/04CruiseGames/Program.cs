using System;

namespace _04CruiseGames
{
    class Program
    {
        static void Main(string[] args)
        {
            // voleyball += 7%; tenis += 5%; badninton += 2%;
            //aveagePoint = 75 win

            string playerName = Console.ReadLine();
            int playedGames = int.Parse(Console.ReadLine());
            double volleballCount = 0;
            double voleyballPoints = 0;
            double tennisCount = 0;
            double tennisPoints = 0;
            double badmintonCount = 0;
            double badmintonPoints = 0;

            for (int i = 1; i <= playedGames; i++)
            {
                string game = Console.ReadLine();
                double points = int.Parse(Console.ReadLine());

                switch (game)
                {
                    case "volleyball":
                        points *= 1.07;
                        volleballCount += 1;
                        voleyballPoints += points;
                        break;

                    case "tennis":
                        points *= 1.05;
                        tennisCount += 1;
                        tennisPoints += points;
                        break;

                    case "badminton":
                        points *= 1.02;
                        badmintonCount += 1;
                        badmintonPoints += points;
                        break;
                }
            }

            double winPoints = voleyballPoints + tennisPoints + badmintonPoints;
            double averageVolleyballPoints = Math.Floor(voleyballPoints / volleballCount * 1.0);
            double averageTennisPoints = Math.Floor(tennisPoints / tennisCount * 1.0);
            double averageBadmintonPoints = Math.Floor(badmintonPoints / badmintonCount * 1.0);

            if (averageVolleyballPoints >= 75 && averageTennisPoints >= 75 && averageBadmintonPoints >= 75)
            {
                Console.WriteLine($"Congratulations, {playerName}! You won the cruise games with {Math.Floor(winPoints)} points.");
            }

            else
            {
                Console.WriteLine($"Sorry, {playerName}, you lost. Your points are only {Math.Floor(winPoints)}.");
            }
        }
    }
}