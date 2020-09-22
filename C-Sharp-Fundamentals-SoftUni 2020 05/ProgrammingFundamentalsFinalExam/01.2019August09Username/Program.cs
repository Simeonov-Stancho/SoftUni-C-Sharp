using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._2019August09Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Sign up")
            {
                List<string> commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "Case")
                {
                    if (commands[1] == "lower")
                    {
                        userName = userName.ToLower();
                    }

                    else if (commands[1] == "upper")
                    {
                        userName = userName.ToUpper();
                    }

                    Console.WriteLine(userName);
                }

                else if (commands[0] == "Reverse")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if ((startIndex >= 0 && startIndex < userName.Length)
                        && (endIndex < userName.Length && endIndex >= startIndex))
                    {
                        string substringPart = userName.Substring(startIndex, endIndex - startIndex + 1);
                        string reversedPart = string.Empty;
                        for (
                            int i = substringPart.Length - 1; i >= 0; i--)
                        {
                            reversedPart += substringPart[i];
                        }
                        Console.WriteLine(reversedPart);

                        //char[] reversed = substringPart.ToCharArray();
                        //Array.Reverse(reversed);
                        //string reversedPart = new string(reversed).ToString();
                        //Console.WriteLine(reversedPart);
                    }
                }

                else if (commands[0] == "Cut")
                {
                    string substring = commands[1];

                    if (userName.Contains(substring))
                    {
                        int index = userName.IndexOf(substring);
                        userName = userName.Remove(index, substring.Length);
                        Console.WriteLine(userName);
                    }

                    else
                    {
                        Console.WriteLine($"The word {userName} doesn't contain {substring}.");
                    }
                }

                else if (commands[0] == "Replace")
                {
                    string oldChar = commands[1];
                    userName = userName.Replace(oldChar, "*");
                    Console.WriteLine(userName);
                }

                else if (commands[0] == "Check")
                {
                    string requeredChar = commands[1];

                    if (userName.Contains(requeredChar))
                    {
                        Console.WriteLine("Valid");
                    }

                    else
                    {
                        Console.WriteLine($"Your username must contain {requeredChar}.");
                    }
                }
            }
        }
    }
}
