using System;

namespace GodzillaKong
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            double budget = double.Parse(Console.ReadLine());
            int man = int.Parse(Console.ReadLine());
            double clothesCost = double.Parse(Console.ReadLine());

            //Caluclation decor=10%*budget
            //Calculation if man>150 clothesCosts=-10%

            double decor = budget * 0.1;
            if (man<=149)
            {
                double clothesCosts = man * clothesCost;
                double totalCost = clothesCosts + decor;

                if (totalCost>budget)
                {
                    double missing = totalCost - budget;
                    Console.WriteLine("Not enough money!");
                    Console.Write($"Wingard needs {missing:f2} leva more.");
                }
                else
                {
                    double extra = budget - totalCost;
                    Console.WriteLine("Action!");
                    Console.Write($"Wingard starts filming with {extra:f2} leva left.");
                }
            }

            else
            {
                double clothesCosts = man * clothesCost * 0.9;
                double totalCost = clothesCosts + decor;
            
            if (totalCost > budget)
            {
                double missing = totalCost - budget;
                Console.WriteLine("Not enough money!");
                Console.Write($"Wingard needs {missing:f2} leva more.");
            }
            else
            {
                double extra = budget - totalCost;
                Console.WriteLine("Action!");
                Console.Write($"Wingard starts filming with {extra:f2} leva left.");
            }
                

            }
        }
    }
}
