using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<double> numbers = new List<double>();

            for (int i = 0; i < input.Length; i++)
            {
                string currentString = input[i];
                char firstChar = currentString[0];
                char lastChar = currentString[currentString.Length - 1];
                string num = currentString.Substring(1, currentString.Length - 2);
                double numberBetween = double.Parse(num);
                double resultedNumber = 0;

                if (firstChar > 64 && firstChar < 91)
                {
                    resultedNumber = numberBetween / (firstChar - 64);
                }

                else if (firstChar > 96 && firstChar < 123)
                {
                    resultedNumber = numberBetween * (firstChar - 96);
                }

                if (lastChar > 64 && lastChar < 91)
                {
                    resultedNumber -= (lastChar - 64);
                }

                else if (lastChar > 96 && lastChar < 123)
                {
                    resultedNumber += (lastChar - 96);
                }

                numbers.Add(resultedNumber);
            }
            double totalSum = numbers.Sum();

            Console.WriteLine($"{ totalSum:f2}");
        }
    }
}
