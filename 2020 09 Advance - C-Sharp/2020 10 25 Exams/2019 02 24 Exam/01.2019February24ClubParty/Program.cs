using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2019February24ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallCapacity = int.Parse(Console.ReadLine());
            string[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Stack<string> input = new Stack<string>(array);
            Queue<int> people = new Queue<int>();
            Queue<string> halls = new Queue<string>();

            int currentGeuests = 0;
            while (input.Count != 0)
            {
                string currentString = input.Peek();

                if (char.IsLetter(currentString[0]))
                {
                    halls.Enqueue(currentString);
                    input.Pop();
                }

                else
                {
                    if (halls.Count == 0)
                    {
                        input.Pop();
                        continue;
                    }

                    if (currentGeuests + int.Parse(currentString) <= hallCapacity)
                    {
                        people.Enqueue(int.Parse(currentString));
                        currentGeuests += int.Parse(input.Pop());
                    }

                    else
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", people)}");
                        people.Clear();
                        currentGeuests = 0;
                    }
                }
            }
        }
    }
}