using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2019December17Santa_sPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> materials = new Stack<int>(ReadInput());
            Queue<int> magicLevel = new Queue<int>(ReadInput());
            int dollCount = 0;
            int trainCount = 0;
            int bearCount = 0;
            int bicycleCount = 0;



            while (materials.Count != 0 && magicLevel.Count != 0)
            {
                int multiplication = materials.Peek() * magicLevel.Peek();

                if (materials.Peek() == 0)
                {
                    materials.Pop();
                    continue;
                }

                if (magicLevel.Peek() == 0)
                {
                    magicLevel.Dequeue();
                    continue;
                }

                else if (multiplication == 150)
                {
                    dollCount++;
                    Remove(materials, magicLevel);
                }

                else if (multiplication == 250)
                {
                    trainCount++;
                    Remove(materials, magicLevel);
                }

                else if (multiplication == 300)
                {
                    bearCount++;
                    Remove(materials, magicLevel);
                }

                else if (multiplication == 400)
                {
                    bicycleCount++;
                    Remove(materials, magicLevel);
                }

                else if (multiplication < 0)
                {
                    int sum = materials.Peek() + magicLevel.Peek();
                    Remove(materials, magicLevel);
                    materials.Push(sum);
                }

                else
                {
                    magicLevel.Dequeue();
                    int currentValue = materials.Peek() + 15;
                    materials.Pop();
                    materials.Push(currentValue);
                }
            }

            if ((dollCount > 0 && trainCount > 0) ||
                (bearCount > 0 && bicycleCount > 0))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }

            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }

            if (magicLevel.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicLevel)}");
            }

            if (bicycleCount > 0)
            {
                Console.WriteLine($"Bicycle: {bicycleCount}");
            }

            if (dollCount > 0)
            {
                Console.WriteLine($"Doll: {dollCount}");
            }

            if (bearCount > 0)
            {
                Console.WriteLine($"Teddy bear: {bearCount}");
            }

            if (trainCount > 0)
            {
                Console.WriteLine($"Wooden train: {trainCount}");
            }

        }

        static List<int> ReadInput()
        {
            return Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse).ToList();
        }

        static void Remove(Stack<int> materials, Queue<int> magicLevel)
        {
            materials.Pop();
            magicLevel.Dequeue();
        }
    }
}