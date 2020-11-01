using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> firstHalf = new Stack<char>();
            Queue<char> secondHalf = new Queue<char>();

            if (input.Length % 2 == 0)
            {
                for (int i = 0; i < (input.Length / 2); i++)
                {
                    firstHalf.Push(input[i]);
                }

                for (int i = input.Length / 2; i < input.Length; i++)
                {
                    secondHalf.Enqueue(input[i]);
                }
            }

            else
            {
                Console.WriteLine("NO");
                return;
            }

            while (firstHalf.Count > 0)
            {
                int firstChar = firstHalf.Peek();
                int secondChar = secondHalf.Peek();

                if ((firstChar=='('&&secondChar==')')
                    || (firstChar == '{' && secondChar == '}')
                    || (firstChar == '[' && secondChar == ']'))
                {
                    firstHalf.Pop();
                    secondHalf.Dequeue();
                    continue;
                }

                if (firstChar == 40)
                {
                    secondChar = secondChar - 1;
                }
                else if (firstChar == 91 || firstChar == 123)
                {
                    secondChar = secondChar - 2;
                }

                if (firstChar == secondChar)
                {
                    firstHalf.Pop();
                    secondHalf.Dequeue();
                }

                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}
