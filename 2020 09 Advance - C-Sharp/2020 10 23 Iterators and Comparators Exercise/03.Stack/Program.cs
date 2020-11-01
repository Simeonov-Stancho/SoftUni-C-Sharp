using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Stack<string> stack = new Stack<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Push")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        stack.Push(command[i]);
                    }
                }

                else if (command[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }

                    catch (InvalidOperationException error)
                    {

                        Console.WriteLine(error.Message);
                    }
                }
            }

            PrintStack(stack);
            PrintStack(stack);
        }

        public static void PrintStack(Stack<string> stack)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
