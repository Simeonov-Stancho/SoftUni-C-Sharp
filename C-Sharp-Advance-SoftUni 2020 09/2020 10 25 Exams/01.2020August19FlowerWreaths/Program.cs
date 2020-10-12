using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2020August19FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lilies = GetInput();
            List<int> roses = GetInput();

            Stack<int> liliesStack = new Stack<int>(lilies);
            Queue<int> rosesQueue = new Queue<int>(roses);
            int wreathCount = 0;
            int storedSum = 0;

            while (liliesStack.Count > 0 && rosesQueue.Count > 0)
            {
                int sum = liliesStack.Peek() + rosesQueue.Peek();

                if (sum == 15)
                {
                    wreathCount++;
                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                }

                else if (sum > 15)
                {
                    int decrease = liliesStack.Peek() - 2;
                    liliesStack.Pop();
                    liliesStack.Push(decrease);
                }

                else
                {
                    storedSum += sum;
                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                }

                if (wreathCount == 5)
                {
                    PrintWreath(wreathCount);
                    return;
                }
            }

            wreathCount += storedSum / 15;

            if (wreathCount >= 5)
            {
                PrintWreath(wreathCount);
            }

            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCount} wreaths more!");
            }
        }

        static List<int> GetInput()
        {
            List<int> input = Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();
            return input;
        }

        static void PrintWreath(int wreathCount)
        {
            Console.WriteLine($"You made it, you are going to the competition with {wreathCount} wreaths!");
        }
    }
}