using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            SortedDictionary<string, Dictionary<string, double>> shopInfo = new SortedDictionary<string, Dictionary<string, double>>();

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] information = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string shop = information[0];
                string product = information[1];
                double price = double.Parse(information[2]);

                if (!shopInfo.ContainsKey(shop))
                {
                    shopInfo.Add(shop, new Dictionary<string, double>());
                }

                shopInfo[shop].Add(product, price);
            }

            foreach (var shop in shopInfo)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: { product.Value}");
                }
            }
        }
    }
}

