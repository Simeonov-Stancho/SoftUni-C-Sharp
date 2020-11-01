using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> data = null;
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentCommand = command[0];

                if (currentCommand == "Create")
                {
                    command = command.Skip(1).ToArray();
                    data = new ListyIterator<string>(command);
                }

                else if (currentCommand == "HasNext")
                {
                    Console.WriteLine(data.HasNext());
                }

                else if (currentCommand == "Move")
                {
                    Console.WriteLine(data.Move());
                }

                else if (currentCommand == "Print")
                {
                    try
                    {
                        data.Print();
                    }
                    catch (InvalidOperationException error)
                    {

                        Console.WriteLine(error.Message);
                    }
                }

                else if (currentCommand == "PrintAll")
                {
                    try
                    {
                        data.PrintAll();
                    }
                    catch (InvalidOperationException error)
                    {

                        Console.WriteLine(error.Message);
                    }
                }
            }
        }
    }
}