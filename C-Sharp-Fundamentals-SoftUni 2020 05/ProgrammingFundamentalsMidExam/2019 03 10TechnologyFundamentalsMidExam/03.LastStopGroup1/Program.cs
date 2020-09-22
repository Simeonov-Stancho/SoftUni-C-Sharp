using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LastStopGroup1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Change")
                {
                    int paintingNumber = int.Parse(command[1]);
                    int changedNumber = int.Parse(command[2]);

                    if (numbers.Contains(paintingNumber))
                    {
                        int index = numbers.IndexOf(paintingNumber);
                        numbers[index] = changedNumber;
                    }
                }

                else if (command[0] == "Hide")
                {
                    int paintingNumber = int.Parse(command[1]);

                    if (numbers.Contains(paintingNumber))
                    {
                        numbers.Remove(paintingNumber);
                    }
                }

                else if (command[0] == "Switch")
                {
                    int paintingNumber1 = int.Parse(command[1]);
                    int paintingNumber2 = int.Parse(command[2]);

                    if (numbers.Contains(paintingNumber1) && numbers.Contains(paintingNumber2))
                    {
                        int index1 = numbers.IndexOf(paintingNumber1);
                        int index2 = numbers.IndexOf(paintingNumber2);

                        numbers[index1] = paintingNumber2;
                        numbers[index2] = paintingNumber1;
                    }
                }

                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[1]);
                    int paintingNumber = int.Parse(command[2]);

                    if (index + 1 > 0 && index < numbers.Count)
                    {
                        numbers.Insert(index + 1, paintingNumber);
                    }
                }

                else if (command[0] == "Reverse")
                {
                    numbers.Reverse();
                }
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
