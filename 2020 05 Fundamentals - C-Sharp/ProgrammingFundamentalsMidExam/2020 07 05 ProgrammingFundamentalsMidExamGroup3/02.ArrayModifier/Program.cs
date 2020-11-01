using System;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commands[0] == "swap")
                {
                    SwapNumbers(numbers, commands);
                }

                else if (commands[0] == "multiply")
                {
                    MultiplyNumbers(numbers, commands);
                }

                else if (commands[0] == "decrease")
                {
                    DecreaseNumbers(numbers, commands);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        static int[] SwapNumbers(int[] numbers, string[] commands)
        {
            int index1 = int.Parse(commands[1]);
            int index2 = int.Parse(commands[2]);

            int numberOne = numbers[index1];
            int numberTwo = numbers[index2];

            numbers[index1] = numberTwo;
            numbers[index2] = numberOne;

            return numbers;
        }

        static int[] MultiplyNumbers(int[] numbers, string[] commands)
        {
            int index1 = int.Parse(commands[1]);
            int index2 = int.Parse(commands[2]);

            int numberOne = numbers[index1];
            int numberTwo = numbers[index2];

            int multiplyNumber = numberOne * numberTwo;

            numbers[index1] = multiplyNumber;

            return numbers;
        }

        static int[] DecreaseNumbers(int[] numbers, string[] commands)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] -= 1;
            }

            return numbers;
        }
    }
}