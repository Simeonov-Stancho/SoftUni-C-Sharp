using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Dictionary<string, List<double>> productPrice = new Dictionary<string, List<double>>();
            List<double> currentProduct = new List<double>();

            while ((command = Console.ReadLine()) != "buy")
            {
                string[] products = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                string product = products[0];
                double price = double.Parse(products[1]);
                int quantity = int.Parse(products[2]);

                if (!productPrice.ContainsKey(product))
                {
                    productPrice.Add(product, new List<double>() { price, quantity });
                }

                else
                {
                    productPrice[product][0] = price;
                    productPrice[product][1] += quantity;
                }
            }

            foreach (var pair in productPrice)
            {
                double totalPrice = productPrice[pair.Key][0] * productPrice[pair.Key][1];
                Console.WriteLine($"{pair.Key} -> {totalPrice:f2}");
            }
        }
    }
}