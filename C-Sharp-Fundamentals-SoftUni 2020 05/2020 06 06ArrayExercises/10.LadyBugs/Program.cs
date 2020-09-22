using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] startingIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] field = new int[fieldSize];

            for (int i = 0; i < startingIndexes.Length; i++)
            {
                if (startingIndexes[i] < fieldSize && startingIndexes[i] >= 0)
                {
                    field[startingIndexes[i]] = 1;
                }
            }

            string input = Console.ReadLine();
            string[] command = new string[3];

            while (input != "end")
            {
                command = input.Split().ToArray();

                int ladyBugIndexes = int.Parse(command[0]);
                string direction = command[1];
                int flyLength = int.Parse(command[2]);

                if (ladyBugIndexes < field.Length && ladyBugIndexes >= 0 && field[ladyBugIndexes] == 1 && flyLength != 0)
                {
                    if (direction == "right")
                    {
                        if (ladyBugIndexes + flyLength < field.Length && ladyBugIndexes + flyLength >= 0 && field[ladyBugIndexes + flyLength] == 0)
                        {
                            field[ladyBugIndexes + flyLength] = 1;
                        }

                        else if (ladyBugIndexes + flyLength < field.Length && ladyBugIndexes + flyLength >= 0 && field[ladyBugIndexes + flyLength] == 1)
                        {
                            while (ladyBugIndexes + flyLength < field.Length && ladyBugIndexes + flyLength >= 0 && field[ladyBugIndexes + flyLength] == 1)
                            {
                                flyLength += flyLength;

                                if (ladyBugIndexes + flyLength < field.Length && ladyBugIndexes + flyLength >= 0 && field[ladyBugIndexes + flyLength] == 0)
                                {
                                    field[ladyBugIndexes + flyLength] = 1;
                                    break;
                                }
                            }
                        }
                    }

                    else if (direction == "left")
                    {
                        if (ladyBugIndexes - flyLength >= 0 && ladyBugIndexes - flyLength < field.Length && field[ladyBugIndexes - flyLength] == 0)
                        {
                            field[ladyBugIndexes - flyLength] = 1;
                        }

                        else if (ladyBugIndexes - flyLength >= 0 && ladyBugIndexes - flyLength < field.Length && field[ladyBugIndexes - flyLength] == 1)
                        {
                            while (ladyBugIndexes - flyLength >= 0 && ladyBugIndexes - flyLength < field.Length && field[ladyBugIndexes - flyLength] == 1)
                            {
                                flyLength += flyLength;

                                if (ladyBugIndexes - flyLength >= 0 && ladyBugIndexes - flyLength < field.Length && field[ladyBugIndexes - flyLength] == 0)
                                {
                                    field[ladyBugIndexes - flyLength] = 1;
                                    break;
                                }
                            }
                        }
                    }

                    field[ladyBugIndexes] = 0;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", field));
        }
    }
}