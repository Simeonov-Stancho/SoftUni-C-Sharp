using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2020June28Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffects = ReadInput();
            int[] bombCasings = ReadInput();

            Queue<int> queue = new Queue<int>(bombEffects);
            Stack<int> stack = new Stack<int>(bombCasings);

            int daturaBombsCount = 0;
            int cherryBombsCount = 0;
            int smokeBombsCount = 0;

            while (!(queue.Count == 0 || stack.Count == 0))
            {
                int sum = queue.Peek() + stack.Peek();

                if (sum == 40)
                {
                    daturaBombsCount++;
                    RemoveElements(queue, stack);
                }

                else if (sum == 60)
                {
                    cherryBombsCount++;
                    RemoveElements(queue, stack);
                }

                else if (sum == 120)
                {
                    smokeBombsCount++;
                    RemoveElements(queue, stack);
                }

                else
                {
                    int newBombCasing = stack.Peek() - 5;
                    stack.Pop();
                    stack.Push(newBombCasing);
                }

                if (daturaBombsCount >= 3 &&
                    cherryBombsCount >= 3 &&
                    smokeBombsCount >= 3)
                {
                    break;
                }
            }

            Printresult(daturaBombsCount, cherryBombsCount, smokeBombsCount);
            PrintBombEffects(queue);
            PrintBombCasings(stack);
            PrintCreatedBombs(daturaBombsCount, cherryBombsCount, smokeBombsCount);
        }

        static void RemoveElements(Queue<int> queue, Stack<int> stack)
        {
            queue.Dequeue();
            stack.Pop();
        }

        private static void PrintCreatedBombs(int daturaBombsCount, int cherryBombsCount, int smokeBombsCount)
        {
            Console.WriteLine($"Cherry Bombs: {cherryBombsCount}");
            Console.WriteLine($"Datura Bombs: {daturaBombsCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeBombsCount}");
        }

        private static void PrintBombCasings(Stack<int> stack)
        {
            if (stack.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", stack)}");
            }
        }

        private static void PrintBombEffects(Queue<int> queue)
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", queue)}");
            }
        }

        private static void Printresult(int daturaBombsCount, int cherryBombsCount, int smokeBombsCount)
        {
            if (daturaBombsCount >= 3 &&
                                cherryBombsCount >= 3 &&
                                smokeBombsCount >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }

            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
        }

        static int[] ReadInput()
        {
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            return input;
        }
    }
}