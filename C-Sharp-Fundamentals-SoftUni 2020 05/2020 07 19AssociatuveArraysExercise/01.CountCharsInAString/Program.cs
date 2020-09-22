using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();

            Dictionary<char, int> character = new Dictionary<char, int>();

            for (int i = 0; i < words.Length; i++)
            {
                char currentChar = words[i];

                if (currentChar == ' ')
                {  
                    continue;
                }

                if (character.ContainsKey(currentChar))
                {
                    character[currentChar]++;
                }

                else
                {
                    character.Add(currentChar, 1);
                }
            }

            foreach (var pair in character)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }


        }
    }
}
