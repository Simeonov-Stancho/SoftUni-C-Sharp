using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<List<int>> pumpsInformation = new Queue<List<int>>();

            for (int i = 0; i < n; i++)
            {
                List<int> array = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                array.Add(i);
                pumpsInformation.Enqueue(array);
            }

            int pumpNumber = 0;
            int pumpPetrol = 0;
            int pumpDistance = 0;
            int currentPetrol = 0;

            for (int i = 0; i < n; i++)
            {
                List<int> currentPump = pumpsInformation.Dequeue();
                pumpPetrol = currentPump[0];
                pumpDistance = currentPump[1];
                pumpNumber = currentPump[2];

                currentPetrol += pumpPetrol;

                if (currentPetrol >= pumpDistance)
                {
                    currentPetrol -= pumpDistance;
                }

                else
                {
                    currentPetrol = 0;
                    i = -1;
                }
                pumpsInformation.Enqueue(currentPump);
            }

            Console.WriteLine(pumpsInformation.Dequeue()[2]);
        }
    }
}
