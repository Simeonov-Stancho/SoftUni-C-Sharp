using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01.SecretChat2020April10
{
    class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Reveal")
            {
                List<string> command = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (command[0] == "InsertSpace")
                {
                    int index = int.Parse(command[1]);

                    concealedMessage = concealedMessage.Insert(index, " ");
                }

                else if (command[0] == "Reverse")
                {
                    string toReverse = command[1];

                    if (!concealedMessage.Contains(toReverse))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    int index = concealedMessage.IndexOf(toReverse);
                    concealedMessage = concealedMessage.Remove(index, toReverse.Length);
                    char[] array = toReverse.ToCharArray();
                    Array.Reverse(array);
                    toReverse = new string(array);
                    concealedMessage = concealedMessage.Insert(concealedMessage.Length, toReverse);
                }

                else if (command[0] == "ChangeAll")
                {
                    string substring = command[1];
                    string replacement = command[2];

                    concealedMessage = concealedMessage.Replace(substring, replacement);
                }

                Console.WriteLine(concealedMessage);
            }

            Console.WriteLine($"You have a new text message: {concealedMessage}");
        }
    }
}