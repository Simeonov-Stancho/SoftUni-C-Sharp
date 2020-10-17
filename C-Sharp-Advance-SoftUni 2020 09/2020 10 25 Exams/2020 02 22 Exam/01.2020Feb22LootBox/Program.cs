using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2020Feb22LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(ReadBox());
            Stack<int> secondLootBox = new Stack<int>(ReadBox());
            int claimendCollection = 0;

            while (firstLootBox.Count != 0 || secondLootBox.Count != 0)
            {
                int sum = firstLootBox.Peek() + secondLootBox.Peek();

                if (sum % 2 == 0)
                {
                    claimendCollection += sum;
                    RemoveItems(firstLootBox, secondLootBox);
                }

                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }

                if (firstLootBox.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }

                if (secondLootBox.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }
            }

            if (claimendCollection >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimendCollection}");
            }

            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimendCollection}");
            }
        }

        static List<int> ReadBox()
        {
            List<int> box = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            return box;
        }

        static void RemoveItems(Queue<int> firstLootBox, Stack<int> secondLootBox)
        {
            firstLootBox.Dequeue();
            secondLootBox.Pop();
        }
    }
}
