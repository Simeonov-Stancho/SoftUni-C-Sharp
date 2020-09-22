using System;
using System.Linq;

namespace _03.RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            double[] numbers = new double[words.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = double.Parse(words[i]);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == -0)
                {
                    numbers[i] = 0;
                }
                Console.WriteLine($"{numbers[i]} => {(int)Math.Round(numbers[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
