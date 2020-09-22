using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WizardPokerGroup1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> availableCards = Console.ReadLine()
                             .Split(":", StringSplitOptions.RemoveEmptyEntries)
                             .ToList();

            List<string> ourCards = new List<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Ready")
            {
                List<string> command = input
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                if (command[0] == "Add")
                {
                    string cardName = command[1];

                    if (availableCards.Contains(cardName))
                    {
                        ourCards.Add(cardName);
                    }

                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }

                else if (command[0] == "Insert")
                {
                    string cardName = command[1];
                    int index = int.Parse(command[2]);

                    if (availableCards.Contains(cardName) && index >= 0 && index < availableCards.Count)
                    {
                        ourCards.Insert(index, cardName);
                    }

                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }

                else if (command[0] == "Remove")
                {
                    string cardName = command[1];

                    if (ourCards.Contains(cardName))
                    {
                        ourCards.Remove(cardName);
                    }

                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }

                else if (command[0] == "Swap")
                {
                    string firstCardName = command[1];
                    string secondCardName = command[2];

                    int firstIndex = ourCards.IndexOf(firstCardName);
                    int secondIndex = ourCards.IndexOf(secondCardName);

                    ourCards[firstIndex] = secondCardName;
                    ourCards[secondIndex] = firstCardName;
                }

                else if (command[0] == "Shuffle")
                {
                    ourCards.Reverse();
                }
            }

            Console.WriteLine(string.Join(" ", ourCards));
        }
    }
}
