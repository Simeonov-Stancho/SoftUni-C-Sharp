using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesisWorking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Queue<char> queue = new Queue<char>(input);

            if (queue.Count % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < queue.Count; i++)
            {
                char firstChar = queue.Dequeue();
                char secondChar = queue.Peek();

                if ((firstChar == '(' && secondChar == ')')
                    || (firstChar == '{' && secondChar == '}')
                    || (firstChar == '[' && secondChar == ']'))
                {
                    queue.Dequeue();
                    i = -1; ;
                    continue;
                }

                else
                {
                    queue.Enqueue(firstChar);
                }
            }

            if (queue.Count != 0)
            {
                Console.WriteLine("NO");
            }

            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
