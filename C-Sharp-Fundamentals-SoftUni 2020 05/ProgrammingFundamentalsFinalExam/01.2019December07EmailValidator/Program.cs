using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._2019December07EmailValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Complete")
            {
                List<string> commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "Make")
                {
                    if (commands[1] == "Upper")
                    {
                        email = email.ToUpper();
                    }

                    else if (commands[1] == "Lower")
                    {
                        email = email.ToLower();
                    }

                    Console.WriteLine(email);
                }

                else if (commands[0] == "GetDomain")
                {
                    int length = int.Parse(commands[1]);

                    if (length > email.Length)
                    {
                        continue;
                    }

                    int startIndex = email.Length - length;

                    string lastCount = email.Substring(startIndex, length);
                    Console.WriteLine(lastCount);
                }

                else if (commands[0] == "GetUsername")
                {
                    if (!email.Contains("@"))
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                        continue;
                    }

                    List<string> userName = email
                        .Split("@", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    Console.WriteLine(userName[0]);
                }

                else if (commands[0] == "Replace")
                {
                    string current = commands[1];

                    email = email.Replace(current, "-");
                    Console.WriteLine(email);
                }

                else if (commands[0] == "Encrypt")
                {
                    List<int> numbers = new List<int>();

                    for (int i = 0; i < email.Length; i++)
                    {
                        int currentASCIIValue = email[i];
                        numbers.Add(currentASCIIValue);
                    }

                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }
    }
}
