using System;
using System.Collections.Generic;
using System.Linq;

namespace Template
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

            while ((input = Console.ReadLine()) != "ENDNDNDN")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "")
                {

                }

                else if (command[0] == "")
                {

                }

                else if (command[0] == "")
                {

                }

                else if (command[0] == "")
                {

                }
            }
        }

        static List<> string TODO1(List<string> numbers, string[] command)
        {

            return
        }

        static List<> string TODO2(List<string> numbers, string[] command)
        {

            return
        }

        static List<> string TODO3(List<string> numbers, string[] command)
        {

            return
        }
        static List<> string TODO4(List<string> numbers, string[] command)
        {

            return
        }
    }
}
