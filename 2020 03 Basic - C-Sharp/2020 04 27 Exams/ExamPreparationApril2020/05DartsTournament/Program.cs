using System;

namespace _05DartsTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingPoints = int.Parse(Console.ReadLine());
            int count = 0;
            bool isWin = false;

            while (startingPoints > 0)
            {
                string sector = Console.ReadLine();
                count += 1;
                if (sector == "bullseye")
                {
                    isWin = true;
                    break;
                }

                int points = int.Parse(Console.ReadLine());

                switch (sector)
                {
                    case "double ring":
                        points = 2 * points;
                        break;

                    case "triple ring":
                        points = 3 * points;
                        break;
                }

                startingPoints -= points;
            }

            if (isWin)
            {
                Console.WriteLine($"Congratulations! You won the game with a bullseye in {count} moves!");
            }

            if (startingPoints == 0)
            {
                Console.WriteLine($"Congratulations! You won the game in {count} moves!");
            }

            else if (startingPoints < 0)
            {
                Console.WriteLine($"Sorry, you lost. Score difference: {-startingPoints}.");
            }

        }
    }
}