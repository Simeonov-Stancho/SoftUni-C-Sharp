using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
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

            while ((input = Console.ReadLine()) != "end")
            {
                List<string> command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .ToList();

                if (command[0] == "Delete")
                {
                    numbers = DeleteNumbers(numbers, int.Parse(command[1]));
                }

                else if (command[0] == "Insert")
                {
                    numbers = InsertNumbers(numbers, int.Parse(command[1]), int.Parse(command[2]));
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static List<int> DeleteNumbers(List<int> numbers, int element)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == element)
                {
                    numbers.Remove(element);
                    i -= 1;
                }
            }

            return numbers;
        }

        static List<int> InsertNumbers(List<int> numbers, int element, int index)
        {
            numbers.Insert(index, element);
            return numbers;
        }
    }
}