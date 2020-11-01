using System;

namespace _01.TheHuntingGamesGroup2
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDayOnePerson = double.Parse(Console.ReadLine());
            double foodPerDayOnePerson = double.Parse(Console.ReadLine());

            double currentEnergy = groupEnergy;
            double currentWater = 0;
            double currentFood = 0;
            currentWater = (players * waterPerDayOnePerson * days);
            currentFood = (players * foodPerDayOnePerson * days);


            for (int i = 1; i <= days; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());


                currentEnergy -= energyLoss;

                if (currentEnergy <= 0)
                {
                    break;
                }

                if (i % 2 == 0)
                {
                    currentEnergy *= 1.05;
                    currentWater *= 0.7;
                }

                if (i % 3 == 0)
                {
                    currentFood -= (currentFood / players);
                    currentEnergy *= 1.1;
                }
            }

            if (currentEnergy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {currentEnergy:f2} energy!");
            }

            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {currentFood:f2} food and {currentWater:f2} water.");
            }
        }
    }
}
