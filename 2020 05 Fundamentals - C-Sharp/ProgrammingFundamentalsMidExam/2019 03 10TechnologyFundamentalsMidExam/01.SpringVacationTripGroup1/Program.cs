using System;

namespace _01.SpringVacationTripGroup1
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int groupPeople = int.Parse(Console.ReadLine());
            double fuelPricePerKM = double.Parse(Console.ReadLine());
            double foodExpensesPerPersonPerDay = double.Parse(Console.ReadLine());
            double roomPricePerPerson = double.Parse(Console.ReadLine());


            if (groupPeople > 10)
            {
                roomPricePerPerson *= 0.75;
            }

            double totalFuelCosts = 0;
            double totalFoodCosts = days * groupPeople * foodExpensesPerPersonPerDay;
            double totalRoomCosts = days * groupPeople * roomPricePerPerson;
            double currentCosts = totalFoodCosts + totalRoomCosts;
            double additionalExpenses = 0;

            double totalCosts = currentCosts;

            for (int i = 1; i <= days; i++)
            {
                double distance = double.Parse(Console.ReadLine());
                totalFuelCosts = fuelPricePerKM * distance;

                totalCosts += totalFuelCosts;

                if (totalCosts > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {(totalCosts - budget):f2}$ more.");
                    return;
                }

                if (i % 3 == 0 || i % 5 == 0)
                {
                    additionalExpenses = totalCosts * 0.4;
                    totalCosts += additionalExpenses;
                    if (totalCosts > budget)
                    {
                        Console.WriteLine($"Not enough money to continue the trip. You need {(totalCosts - budget):f2}$ more.");
                        return;
                    }
                }

                if (i % 7 == 0)
                {
                    totalCosts -= (totalCosts / groupPeople);
                    if (totalCosts > budget)
                    {
                        Console.WriteLine($"Not enough money to continue the trip. You need {(totalCosts - budget):f2}$ more.");
                        return;
                    }
                }
            }

            Console.WriteLine($"You have reached the destination. You have {(budget - totalCosts):f2}$ budget left.");
        }
    }
}
