using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double sum = 0;
            double price = 0;

            while (input != "Start")
            {
                double money = double.Parse(input);

                if (money != 0.1 && money != 0.2 && money != 0.5 && money != 1 && money != 2)
                {
                    Console.WriteLine($"Cannot accept {money}");
                    money = 0;
                }
                sum += money;
                input = Console.ReadLine();
            }

            while (input != "End")
            {
                input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (input != "Nuts" && input != "Water" && input != "Crisps" && input != "Soda" && input != "Coke")
                {
                    Console.WriteLine("Invalid product");
                }

                else
                {
                    switch (input)
                    {
                        case "Nuts":
                            price = 2.0;
                            break;

                        case "Water":
                            price = 0.7;
                            break;

                        case "Crisps":
                            price = 1.5;
                            break;

                        case "Soda":
                            price = 0.8;
                            break;

                        case "Coke":
                            price = 1.0;
                            break;
                    }

                    if (price <= sum)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        sum -= price;
                    }

                    else
                    {
                        Console.WriteLine($"Sorry, not enough money");
                    }
                }

            }
            if (input == "End")
            {
                Console.WriteLine($"Change: {sum:f2}");
            }
        }
    }
}