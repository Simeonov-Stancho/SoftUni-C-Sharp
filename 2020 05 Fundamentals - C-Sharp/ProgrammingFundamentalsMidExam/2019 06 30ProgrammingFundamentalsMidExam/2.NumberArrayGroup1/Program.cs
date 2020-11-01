using System;
using System.Linq;

namespace _2.NumberArrayGroup1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                if (commands[0] == "Switch")
                {
                    int index = int.Parse(commands[1]);

                    if (index >= 0 && index < numbers.Length)
                    {
                        int currentNum = -numbers[index];
                        numbers[index] = currentNum;
                    }
                }

                else if (commands[0] == "Change")
                {
                    int index = int.Parse(commands[1]);
                    int value = int.Parse(commands[2]);

                    if (index >= 0 && index < numbers.Length)
                    {
                        numbers[index] = value;
                    }
                }

                else if (commands[1] == "Negative")
                {
                    int sum = 0;

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] < 0)
                        {
                            sum += numbers[i];
                        }
                    }

                    Console.WriteLine(sum);
                }

                else if (commands[1] == "Positive")
                {
                    int sum = 0;

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] >= 0)
                        {
                            sum += numbers[i];
                        }
                    }

                    Console.WriteLine(sum);
                }

                else if (commands[1] == "All")
                {
                    int sum = numbers.Sum();
                    Console.WriteLine(sum);
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] >= 0)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }

        }
    }
}
