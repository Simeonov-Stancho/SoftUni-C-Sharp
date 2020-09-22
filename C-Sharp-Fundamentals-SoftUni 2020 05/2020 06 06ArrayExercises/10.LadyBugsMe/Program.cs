using System;
using System.Linq;

namespace _10.LadyBugsMe
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] ladyBugsOnField = new int[fieldSize];

            for (int i = 0; i < indexes.Length; i++)
            {
                if ((ladyBugsOnField[indexes[i]]) >= 0 &&
                    (ladyBugsOnField[indexes[i]]) <= (fieldSize - 1))
                {
                    ladyBugsOnField[indexes[i]] = 1;
                }
            }

            string command = "";

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArray = command.
                    Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int ladyBugIndex = int.Parse(commandArray[0]);
                string direction = commandArray[1];
                int flyLenght = int.Parse(commandArray[2]);

                if (ladyBugIndex < 0 ||
                    ladyBugIndex > ladyBugsOnField.Length - 1 ||
                    ladyBugsOnField[ladyBugIndex] == 0)
                {
                    continue;
                }

                ladyBugsOnField[ladyBugIndex] = 0;

                if (commandArray[1] == "right")
                {
                    int endIndex = ladyBugIndex + flyLenght;

                    if (endIndex > ladyBugsOnField.Length - 1)
                    {
                        continue;
                    }

                    if (ladyBugsOnField[endIndex] == 1)
                    {
                        while (ladyBugsOnField[endIndex] == 1)
                        {
                            endIndex += flyLenght;

                            if (endIndex > ladyBugsOnField.Length - 1)
                            {
                                break;
                            }
                        }

                        if (endIndex >= 0 && endIndex < ladyBugsOnField.Length)
                        {
                            ladyBugsOnField[endIndex] = 1;
                        }
                    }
                }

                else if (commandArray[1] == "left")
                {
                    int endIndex = ladyBugIndex - flyLenght;

                    if (endIndex < 0)
                    {
                        continue;
                    }

                    if (ladyBugsOnField[endIndex] == 1)
                    {
                        while (ladyBugsOnField[endIndex] == 1)
                        {
                            endIndex -= flyLenght;

                            if (endIndex < 0)
                            {
                                break;
                            }
                        }
                    }

                    if (endIndex >= 0 && endIndex < ladyBugsOnField.Length)
                    {
                        ladyBugsOnField[endIndex] = 1;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", ladyBugsOnField));
        }
    }
}
