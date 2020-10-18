using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2019October26DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> male = new Stack<int>(ReadInput());
            Queue<int> female = new Queue<int>(ReadInput());
            int matchesCount = 0;

            while (male.Count != 0 && female.Count != 0)
            {
                if (male.Peek() <= 0 && female.Peek() <= 0)
                {
                    Remove(male, female);
                    continue;
                }

                if (male.Peek() <= 0)
                {
                    male.Pop();
                    continue;
                }

                if (female.Peek() <= 0)
                {
                    female.Dequeue();
                    continue;
                }

                if (male.Peek() % 25 == 0 && female.Peek() % 25 == 0)
                {
                    Remove(male, female);
                    Remove(male, female);
                    continue;
                }

                if (male.Peek() % 25 == 0)
                {
                    male.Pop();
                    male.Pop();
                    continue;
                }

                if (female.Peek() % 25 == 0)
                {
                    female.Dequeue();
                    female.Dequeue();
                    continue;
                }

                else if (male.Peek() == female.Peek())
                {
                    matchesCount++;
                    Remove(male, female);
                }

                else
                {
                    female.Dequeue();
                    int maleValue = male.Peek() - 2;
                    male.Pop();
                    male.Push(maleValue);
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");

            if (male.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }

            else
            {
                Console.WriteLine($"Males left: { string.Join(", ", male)}");
            }

            if (female.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }

            else
            {
                Console.WriteLine($"Females left: { string.Join(", ", female)}");
            }
        }

        static List<int> ReadInput()
        {
            return Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse).ToList();
        }

        static void Remove(Stack<int> male, Queue<int> female)
        {
            male.Pop();
            female.Dequeue();
        }
    }
}
