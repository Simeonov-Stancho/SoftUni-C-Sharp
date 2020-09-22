using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int group = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;

            if (groupType == "Students")
            {
                switch (day)
                {
                    case "Friday":
                        price = 8.45;
                        break;

                    case "Saturday":
                        price = 9.80;
                        break;

                    case "Sunday":
                        price = 10.46;
                        break;
                }
                if (group >= 30)
                {
                    price *= 0.85;
                }
            }
            else if (groupType == "Business")
            {
                switch (day)
                {
                    case "Friday":
                        price = 10.9;
                        break;

                    case "Saturday":
                        price = 15.60;
                        break;

                    case "Sunday":
                        price = 16.00;
                        break;
                }
                if (group >= 100)
                {
                    group -= 10;
                }
            }
            else if (groupType == "Regular")
            {
                switch (day)
                {
                    case "Friday":
                        price = 15.0;
                        break;

                    case "Saturday":
                        price = 20.0;
                        break;

                    case "Sunday":
                        price = 22.50;
                        break;
                }
                if (group >= 10 && group <= 20)
                {
                    price *= 0.95;
                }
            }

            Console.WriteLine($"Total price: {group * price:f2}");
        }
    }
}
