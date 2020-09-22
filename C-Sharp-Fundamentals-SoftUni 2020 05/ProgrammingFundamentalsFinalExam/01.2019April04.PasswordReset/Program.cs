using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._2010April04.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Done")
            {
                List<string> commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "TakeOdd")
                {
                    int length = password.Length;

                    for (int i = 0; i < length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            password += (password[i]);
                        }
                    }
                    password = password.Remove(0, length);

                    Console.WriteLine(password);
                }

                else if (commands[0] == "Cut")
                {
                    int index = int.Parse(commands[1]);
                    int length = int.Parse(commands[2]);

                    string cut = password.Substring(index, length);
                    int cutIndex = password.IndexOf(cut);

                    password = password.Remove(cutIndex, cut.Length);
                    Console.WriteLine(password);
                }

                else if (commands[0] == "Substitute")
                {
                    string substring = commands[1];
                    string substitute = commands[2];

                    if (!password.Contains(substring))
                    {
                        Console.WriteLine("Nothing to replace!");
                        continue;
                    }

                    password = password.Replace(substring, substitute);

                    Console.WriteLine(password);
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
