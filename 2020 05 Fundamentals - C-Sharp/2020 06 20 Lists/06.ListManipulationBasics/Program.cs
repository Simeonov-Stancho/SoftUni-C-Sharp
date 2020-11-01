using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = ReadList();
            string input = string.Empty;
            List<string> command = new List<string>();

            while ((input = Console.ReadLine()) != "end")
            {
                command = input.Split(" ").ToList();
                int num = int.Parse(command[1]);

                if (command[0] == "Add")
                {
                    numbers.Add(num);
                }

                else if (command[0] == "Remove")
                {
                    numbers.Remove(num);
                }

                else if (command[0] == "RemoveAt")
                {
                    numbers.RemoveAt(num);
                }

                else if (command[0] == "Insert")
                {
                    numbers.Insert(int.Parse(command[2]), num);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static List<int> ReadList()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            return numbers;
        }


    }
}
