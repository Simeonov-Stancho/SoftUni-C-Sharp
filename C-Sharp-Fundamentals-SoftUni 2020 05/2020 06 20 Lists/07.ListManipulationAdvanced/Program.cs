using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = ReadList();
            string input = string.Empty;
            List<string> command = new List<string>();
            bool isChange = false;
            List<int> newList = numbers;

            while ((input = Console.ReadLine()) != "end")
            {
                command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (command[0] == "Contains")
                {
                    PrintIsListContains(numbers, command);
                }

                else if (command[0] == "PrintEven")
                {
                    PrintListEven(numbers);
                }

                else if (command[0] == "PrintOdd")
                {
                    PrintListOdd(numbers);
                }

                else if (command[0] == "GetSum")
                {
                    PrintGetSum(numbers);
                }

                else if (command[0] == "Filter")
                {
                    PrintFilter(numbers, command);
                }

                else if (command[0] == "Add")
                {
                    newList.Add(int.Parse(command[1]));
                    isChange = true;
                }

                else if (command[0] == "Remove")
                {
                    newList.Remove(int.Parse(command[1]));
                    isChange = true;
                }

                else if (command[0] == "RemoveAt")
                {
                    newList.RemoveAt(int.Parse(command[1]));
                    isChange = true;
                }

                else if (command[0] == "Insert")
                {
                    newList.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    isChange = true;
                }
            }

            if (isChange)
            {
                Console.WriteLine(string.Join(" ", newList));
            }
        }

        static List<int> ReadList()
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            return numbers;
        }

        static void PrintIsListContains(List<int> numbers, List<string> command)
        {
            int num = int.Parse(command[1]);
            bool isContain = numbers.Contains(num);

            if (isContain)
            {
                Console.WriteLine("Yes");
            }

            else
            {
                Console.WriteLine("No such number");
            }
        }

        static void PrintListEven(List<int> numbers)
        {
            List<int> evenList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenList.Add(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ", evenList));
        }

        static void PrintListOdd(List<int> numbers)
        {
            List<int> oddList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    oddList.Add(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ", oddList));
        }

        static void PrintGetSum(List<int> numbers)
        {
            int sum = numbers.Sum(x => Convert.ToInt32(x));

            Console.WriteLine(sum);
        }

        static void PrintFilter(List<int> numbers, List<string> command)
        {
            List<int> newList = new List<int>();

            if (command[1] == "<")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] < int.Parse(command[2]))
                    {
                        newList.Add(numbers[i]);
                    }
                }
            }

            else if (command[1] == ">")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] > int.Parse(command[2]))
                    {
                        newList.Add(numbers[i]);
                    }
                }
            }

            else if (command[1] == ">=")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] >= int.Parse(command[2]))
                    {
                        newList.Add(numbers[i]);
                    }
                }
            }

            else if (command[1] == "<=")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= int.Parse(command[2]))
                    {
                        newList.Add(numbers[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", newList));
        }
    }
}
