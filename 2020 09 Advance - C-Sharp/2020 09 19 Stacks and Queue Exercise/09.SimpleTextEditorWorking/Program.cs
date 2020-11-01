using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> text = new Stack<string>();
            StringBuilder builder = new StringBuilder();
            text.Push(builder.ToString());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int commandNumber = int.Parse(command[0]);

                switch (commandNumber)
                {
                    case 1:
                        string someString = command[1];
                        builder.Append(someString);
                        text.Push(builder.ToString());
                        break;

                    case 2:
                        int count = int.Parse(command[1]);
                        builder.Remove((builder.Length - count), count);
                        text.Push(builder.ToString());
                        break;

                    case 3:
                        int index = int.Parse(command[1]);
                        Console.WriteLine(builder[index - 1]);
                        break;

                    case 4:
                        text.Pop();
                        builder = new StringBuilder();
                        builder.Append(text.Peek());
                        break;
                }
            }
        }
    }
}
