using System;

namespace _07.TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int price = 0;

            if (0 <= age && age <= 18)
            {
                switch (day)
                {
                    case "Weekday":
                        price = 12;
                        break;

                    case "Weekend":
                        price = 15;
                        break;

                    case "Holiday":
                        price = 5;
                        break;
                }
                Console.WriteLine($"{price}$");
            }
            else if (18 < age && age <= 64)
            {
                switch (day)
                {
                    case "Weekday":
                        price = 18;
                        break;

                    case "Weekend":
                        price = 20;
                        break;

                    case "Holiday":
                        price = 12;
                        break;
                }
                Console.WriteLine($"{price}$");
            }
            else if (64 < age && age <= 122)
            {
                switch (day)
                {
                    case "Weekday":
                        price = 12;
                        break;

                    case "Weekend":
                        price = 15;
                        break;

                    case "Holiday":
                        price = 10;
                        break;
                }
                Console.WriteLine($"{price}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
