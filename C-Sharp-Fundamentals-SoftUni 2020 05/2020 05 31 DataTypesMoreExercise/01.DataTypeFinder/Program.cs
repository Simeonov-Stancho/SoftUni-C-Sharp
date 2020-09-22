using System;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {

            string command = Console.ReadLine();
            string type = "";

            while (command != "END")
            {
                int integerVal = 0;
                double doubleVal = 0;
                char charVal = ' ';
                bool booleanVal = false;
                bool success = false;

                if (success = Int32.TryParse(command, out integerVal))
                {
                    type = "integer type";
                }

                else if (success = Double.TryParse(command, out doubleVal))
                {
                    type = "floating point type";
                }

                else if (success = Char.TryParse(command, out charVal))
                {
                    type = "character type";
                }

                else if (success = Boolean.TryParse(command, out booleanVal))
                {
                    type = "boolean type";
                }

                else
                {
                    type = "string type";
                }

                Console.WriteLine($"{command} is {type}");
                command = Console.ReadLine();
            }
        }
    }
}
