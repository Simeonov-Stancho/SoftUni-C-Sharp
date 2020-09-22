using System;

namespace _01.DisneylandJourney
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());

            double savedMoney = 0;

            for (int i = 1; i <= months; i++)
            {
                if (i % 2 != 0 && i != 1)
                {
                    savedMoney *= 0.84;
                }

                if (i % 4 == 0)
                {
                    savedMoney *= 1.25;
                }
                savedMoney += 0.25 * budget;
            }

            if (budget > savedMoney)
            {
                Console.WriteLine($"Sorry. You need {(budget - savedMoney):f2}lv. more.");
            }

            else
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {(savedMoney - budget):f2}lv. for souvenirs.");

            }
        }
    }
}
