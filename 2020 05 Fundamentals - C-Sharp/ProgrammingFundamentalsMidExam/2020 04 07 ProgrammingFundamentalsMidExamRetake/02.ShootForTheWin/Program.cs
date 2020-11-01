using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> shotTarget = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = string.Empty;
            int count = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                int index = int.Parse(command);

                if (index < 0 || index >= shotTarget.Count)
                {
                    continue;
                }

                int currentTarget = shotTarget[index];

                if (currentTarget == -1)
                {
                    continue;
                }

                for (int i = 0; i < shotTarget.Count; i++)
                {
                    if (i == index)
                    {
                        shotTarget[i] = -1;
                    }

                    else if (shotTarget[i] == -1)
                    {
                        continue;
                    }

                    else if (shotTarget[i] > currentTarget)
                    {
                        shotTarget[i] -= currentTarget;
                    }

                    else if (shotTarget[i] <= currentTarget)
                    {
                        shotTarget[i] += currentTarget;
                    }
                }

                count++;
            }
            Console.Write($"Shot targets: {count} -> ");
            Console.WriteLine(string.Join(" ", shotTarget));
        }
    }
}
