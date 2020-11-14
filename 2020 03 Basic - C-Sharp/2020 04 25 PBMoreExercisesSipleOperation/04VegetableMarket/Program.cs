using System;

namespace _04VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegetablePrice = double.Parse(Console.ReadLine());
            double fruitPrice = double.Parse(Console.ReadLine());
            int vegetable = int.Parse(Console.ReadLine());
            int fruit = int.Parse(Console.ReadLine());

            double totalIncome = (vegetablePrice * vegetable + fruitPrice * fruit) / 1.94;

            Console.WriteLine($"{totalIncome:f2}");
        }
    }
}
