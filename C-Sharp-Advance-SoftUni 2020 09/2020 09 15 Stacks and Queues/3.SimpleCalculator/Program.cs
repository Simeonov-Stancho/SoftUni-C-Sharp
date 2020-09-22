using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Stack<string> stack = new Stack<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }

            while (stack.Count > 1)
            {
                int firstDigit = int.Parse(stack.Pop());
                string expressions = stack.Pop();
                int secondDigit = int.Parse(stack.Pop());

                int currentSum = 0;

                if (expressions == "+")
                {
                    currentSum = firstDigit + secondDigit;
                }

                else if (expressions == "-")
                {
                    currentSum = firstDigit - secondDigit;
                }

                stack.Push(currentSum.ToString());
            }

            Console.WriteLine(stack.Pop());

        }
    }
}
