using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            bool isValid = true;

            for (int i = 0; i < userNames.Length; i++)
            {
                string currentUserName = userNames[i];

                if (currentUserName.Length > 2 && currentUserName.Length < 17)
                {
                    for (int j = 0; j < currentUserName.Length; j++)
                    {
                        char currentChar = currentUserName[j];
                        if (char.IsDigit(currentChar) || char.IsLetter(currentChar)
                            || currentChar == '-' || currentChar == '_')
                        {
                            isValid = true;
                        }

                        else
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        Console.WriteLine(currentUserName);
                    }
                }
            }
        }
    }
}
