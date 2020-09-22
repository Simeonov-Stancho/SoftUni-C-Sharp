using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _02.ArcheryTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                            .Split("|", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

            string input = string.Empty;
            int points = 0;

            while ((input = Console.ReadLine()) != "Game over")
            {
                List<string> commands = input
                    .Split("@", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "Shoot Left")
                {
                    int startIndex = int.Parse(commands[1]);
                    int length = int.Parse(commands[2]);

                    int currentIndex = startIndex;

                    if (startIndex < 0 || startIndex >= targets.Count)
                    {
                        continue;
                    }

                    while (length > 0)
                    {
                        length--;
                        currentIndex--;

                        if (currentIndex < 0)
                        {
                            currentIndex = targets.Count-1;
                        }
                    }

                    if (targets[currentIndex] > 4)
                    {
                        targets[currentIndex] -= 5;
                        points += 5;
                    }

                    else
                    {
                        points += targets[currentIndex];
                        targets[currentIndex] = 0;
                    }
                }




                else if (commands[0] == "Shoot Right")
                {
                    int startIndex = int.Parse(commands[1]);
                    int length = int.Parse(commands[2]);

                    if (startIndex < 0 || startIndex >= targets.Count)
                    {
                        continue;
                    }

                    int count = 0;
                    int currentIndex = startIndex;

                    while (count != length)
                    {
                        count++;

                        if (currentIndex > targets.Count - 1)
                        {
                            currentIndex = 0;
                        }

                        currentIndex++;
                    }

                    if (targets[currentIndex] > 4)
                    {
                        targets[currentIndex] -= 5;
                        points += 5;
                    }

                    else
                    {
                        points += targets[currentIndex];
                        targets[currentIndex] = 0;
                    }
                }

                else if (commands[0] == "Reverse")
                {
                    List<int> reversedList = new List<int>(targets.Count);

                    for (int i = 0; i < targets.Count; i++)
                    {
                        reversedList.Insert(i, targets[targets.Count - 1 - i]);
                    }

                    targets = reversedList;
                }
            }

            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
