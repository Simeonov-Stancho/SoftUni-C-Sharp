using System;
using System.Text.RegularExpressions;

namespace _02._2019August09
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"^(.+)\>(?<firstGroup>[0-9]{3})\|(?<secondGroup>[a-z]{3})\|(?<thirdGroup>[A-Z]{3})\|(?<fourthGroup>[^\<\>]{3})\<\1$";
                Regex regex = new Regex(pattern);

                Match validPassword = regex.Match(input);

                if (!regex.IsMatch(input))
                {
                    Console.WriteLine("Try another password!");
                }

                else
                {
                    string encryptedPassword = string.Empty;
                    encryptedPassword = validPassword.Groups["firstGroup"].Value
                                + validPassword.Groups["secondGroup"].Value
                                + validPassword.Groups["thirdGroup"].Value
                                + validPassword.Groups["fourthGroup"].Value;
                    Console.WriteLine($"Password: { encryptedPassword}");
                }
            }
        }
    }
}
