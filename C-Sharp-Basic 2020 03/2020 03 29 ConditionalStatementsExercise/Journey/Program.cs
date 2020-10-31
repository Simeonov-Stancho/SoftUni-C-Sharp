using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string type = "";
            string place = "";
            double costs = 0;

            if (budget <= 100)
            {
                place = "Bulgaria";
                if (season == "summer")
                {
                    type = "Camp";
                    costs = budget * 0.3;
                }
                else
                {
                    type = "Hotel";
                    costs = budget * 0.7;
                }
            }

            else if (budget <= 1000)
            {
                place = "Balkans";
                if (season == "summer")
                {
                    type = "Camp";
                    costs = budget * 0.4;
                }
                else
                {
                    type = "Hotel";
                    costs = budget * 0.8;
                }
            }
            else
            {
                place = "Europe";
                type = "Hotel";
                costs = budget * 0.9;
            }

            Console.WriteLine($"Somewhere in {place}");
            Console.WriteLine($"{type} - {costs:f2}");
        }
    }
}
