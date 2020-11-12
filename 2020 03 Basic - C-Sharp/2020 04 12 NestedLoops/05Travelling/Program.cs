using System;

namespace _05Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = "";
            while (destination != "End")
            {
                destination = Console.ReadLine();
                if (destination == "End")
                {
                    break;
                }

                double budget = double.Parse(Console.ReadLine());
                double money = 0;

                while (budget > money)
                {
                    double newSum = double.Parse(Console.ReadLine());
                    money += newSum;

                    if (budget <= money)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                }
            }
        }
    }
}
