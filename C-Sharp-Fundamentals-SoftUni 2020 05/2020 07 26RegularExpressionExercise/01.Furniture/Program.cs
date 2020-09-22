using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            string pattern = @">>(?<furnitureName>.+)<<(?<price>[0-9]+[.]?[0-9]*)!(?<quantity>[0-9]+)";
            double spendMoney = 0;
            List<string> boughtFurniture = new List<string>();

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Regex furnitures = new Regex(pattern);

                MatchCollection matchedFurnitures = furnitures.Matches(input);

                foreach (Match furniture in matchedFurnitures)
                {
                    boughtFurniture.Add(furniture.Groups["furnitureName"].Value);
                    spendMoney += double.Parse(furniture.Groups["price"].Value) * double.Parse(furniture.Groups["quantity"].Value);
                }
            }

            Console.WriteLine("Bought furniture:");

            if (spendMoney > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, boughtFurniture).Trim());
            }
            Console.WriteLine($"Total money spend: {spendMoney:f2}");
        }
    }
}