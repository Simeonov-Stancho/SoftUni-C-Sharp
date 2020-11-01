using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
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

            while ((input = Console.ReadLine()) != "End")
            {
                List<string> command = input
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToList();

                if (command[0] == "Add")
                {
                    AddNumber(numbers, command[1]);
                }

                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[2]);
                    if ( index < 0 || (numbers.Count - 1) < index)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    InsertNumber(numbers, command[1], index);
                }

                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);
                    if (index < 0 || (numbers.Count - 1) < index)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    RemoveNumber(numbers, index);
                }

                else if (command[1] == "left")
                {
                    ShiftLeftNumber(numbers, command[2]);
                }

                else if (command[1] == "right")
                {
                    ShiftRightNumber(numbers, command[2]);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static List<int> AddNumber(List<int> number, string input)
        {
            number.Add(int.Parse(input));
            return number;
        }

        static List<int> InsertNumber(List<int> number, string num, int index)
        {
            number.Insert(index, int.Parse(num));
            return number;
        }

        static List<int> RemoveNumber(List<int> number, int index)
        {
            number.RemoveAt(index);
            return number;
        }

        static List<int> ShiftLeftNumber(List<int> number, string count)
        {
            List<int> shiftList = number;
            for (int i = 0; i < int.Parse(count); i++)
            {
                int firstDigit = number[0];

                for (int j = 0; j < number.Count - 1; j++)
                {
                    shiftList[j] = number[j + 1];
                }
                shiftList[shiftList.Count - 1] = firstDigit;

                number = shiftList;
            }

            return number;
        }

        static List<int> ShiftRightNumber(List<int> number, string count)
        {
            List<int> shiftList = number;
            for (int i = 0; i < int.Parse(count); i++)
            {
                int lastDigit = number[number.Count - 1];

                for (int j = number.Count - 1; j >= 1; j--)
                {
                    shiftList[j] = number[j - 1];
                }
                shiftList[0] = lastDigit;

                number = shiftList;
            }

            return number;
        }
    }
}
