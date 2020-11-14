using System;

namespace _01Savings
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double costs = double.Parse(Console.ReadLine());

            double savings = (income * 0.7 - costs);

            Console.WriteLine($"She can save {(savings / income)*100:f2}%");
            Console.WriteLine($"{months * savings:f2}");
        }
    }
}