using System;
using System.Linq;

namespace _02.EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gifts = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "No Money")
            {
                string[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commands[0] == "OutOfStock")
                {
                    for (int i = 0; i < gifts.Length; i++)
                    {
                        if (gifts[i] == commands[1])
                        {
                            gifts[i] = "None";
                        }
                    }
                }

                else if (commands[0] == "Required")
                {
                    int index = int.Parse(commands[2]);

                    if (index >= 0 && index < gifts.Length)
                    {
                        gifts[index] = commands[1];
                    }
                }

                else if (commands[0] == "JustInCase")
                {
                    gifts[gifts.Length - 1] = commands[1];
                }
            }

            for (int i = 0; i < gifts.Length; i++)
            {
                if (gifts[i] != "None")
                {
                    Console.Write($"{gifts[i]} ");
                }
            }
            Console.WriteLine();
        }
    }
}
