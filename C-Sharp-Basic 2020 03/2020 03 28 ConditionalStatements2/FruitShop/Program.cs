using System;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double qty = double.Parse(Console.ReadLine());

            double price = 0;

            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (fruit == "banana")
                {
                    price = 2.50;
                    Console.WriteLine($"{(qty * price):f2}");
                }
                else if (fruit == "apple")
                {
                    price = 1.20;
                    Console.WriteLine($"{(qty * price):f2}");
                }
                else if (fruit == "orange")
                {
                    price = 0.85;
                    Console.WriteLine($"{(qty * price):f2}");
                }
                else if (fruit == "grapefruit")
                {
                    price = 1.45;
                    Console.WriteLine($"{(qty * price):f2}");
                }
                else if (fruit == "kiwi")
                {
                    price = 2.70;
                    Console.WriteLine($"{(qty * price):f2}");
                }
                else if (fruit == "pineapple")
                {
                    price = 5.50;
                    Console.WriteLine($"{(qty * price):f2}");
                }
                else if (fruit == "grapes")
                {
                    price = 3.85;
                    Console.WriteLine($"{(qty * price):f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            else if (day == "Sunday" || day == "Saturday")
            {
                    if (fruit == "banana")
                    {
                        price = 2.70;
                        Console.WriteLine($"{(qty * price):f2}");
                    }
                    else if (fruit == "apple")
                    {
                        price = 1.25;
                        Console.WriteLine($"{(qty * price):f2}");
                    }
                    else if (fruit == "orange")
                    {
                        price = 0.90;
                        Console.WriteLine($"{(qty * price):f2}");
                    }
                    else if (fruit == "grapefruit")
                    {
                        price = 1.60;
                        Console.WriteLine($"{(qty * price):f2}");
                    }
                    else if (fruit == "kiwi")
                    {
                        price = 3.00;
                        Console.WriteLine($"{(qty * price):f2}");
                    }
                    else if (fruit == "pineapple")
                    {
                        price = 5.60;
                        Console.WriteLine($"{(qty * price):f2}");
                    }
                    else if (fruit == "grapes")
                    {
                        price = 4.20;
                        Console.WriteLine($"{(qty * price):f2}");
                     }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
                       
        }
    }
}
