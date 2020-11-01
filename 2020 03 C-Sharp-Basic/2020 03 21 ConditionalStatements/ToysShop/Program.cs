using System;

namespace ToysShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //read 

            double priceЕxcursion = double.Parse(Console.ReadLine());
            int countPuzzle = int.Parse(Console.ReadLine());
            int countDolls = int.Parse(Console.ReadLine());
            int countBears = int.Parse(Console.ReadLine());
            int countMinions = int.Parse(Console.ReadLine());
            int countTrucks = int.Parse(Console.ReadLine());

            //count if >=50 disc25%, rent 10%
            int countToys = countPuzzle + countDolls + countBears + countMinions + countTrucks;
            double valueToys = countPuzzle * 2.60 + countDolls * 3.00 + countBears * 4.10 + countMinions * 8.20 + countTrucks * 2.00;

            if (countToys >= 50)
            {
                double Amount = valueToys * 0.75;
                double rent = Amount * 0.10;
                double totalAmount = Amount - rent;

                if (totalAmount >= priceЕxcursion)
                {
                    double rest = totalAmount - priceЕxcursion;
                    Console.WriteLine($"Yes! { rest:f2} lv left.");
                }
                else
                {
                    double shortage = priceЕxcursion - totalAmount;
                    Console.WriteLine($"Not enough money! { shortage:f2} lv needed.");
                }
            }
            else if (countToys < 50)
            {
                double Amount = valueToys;
                double rent = Amount * 0.10;
                double totalAmount = Amount - rent;

                if (totalAmount >= priceЕxcursion)
                {
                    double rest = totalAmount - priceЕxcursion;
                    Console.WriteLine($"Yes! { rest:f2} lv left.");
                }
                else
                {
                    double shortage = priceЕxcursion - totalAmount;
                    Console.WriteLine($"Not enough money! { shortage:f2} lv needed.");
                }
            }
        }
    }
}
