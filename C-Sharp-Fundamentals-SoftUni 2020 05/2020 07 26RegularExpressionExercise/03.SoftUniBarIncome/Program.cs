using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            double income = 0;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*[|](?<count>\d+)[|][^|$%.]*?(?<price>\d+[.]?\d*)[$][^|$%.]*";

                Regex regex = new Regex(pattern);
                Match name = regex.Match(input);

                if (regex.IsMatch(input) == false)
                {
                    continue;
                }

                string customerName = name.Groups["customer"].Value;
                string product = name.Groups["product"].Value;
                int count = int.Parse(name.Groups["count"].Value);
                double price = double.Parse(name.Groups["price"].Value);

                double totalPrice = count * price;
                income += totalPrice;

                Console.WriteLine($"{customerName}: {product} - {totalPrice:f2}");
            }

            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
