using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            OrdersSum(Console.ReadLine(), int.Parse(Console.ReadLine()));
        }

        static void OrdersSum(string type, int quatity)
        {
            double price = 0;
            switch (type)
            {
                case "coffee":
                    price = 1.5;
                    break;

                case "water":
                    price = 1;
                    break;

                case "coke":
                    price = 1.4;
                    break;

                case "snacks":
                    price = 2;
                    break;
            }

            double result = price * quatity;
            Console.WriteLine($"{result:f2}");
        }
    }
}
