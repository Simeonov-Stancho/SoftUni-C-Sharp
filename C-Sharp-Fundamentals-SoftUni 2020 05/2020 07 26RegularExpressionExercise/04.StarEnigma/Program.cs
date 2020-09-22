using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> attackedPlanet = new List<string>();
            List<string> destroyedPlanet = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int charCount = 0;
                string decryptedMessage = string.Empty;

                for (int j = 0; j < input.Length; j++)
                {
                    char currentChar = input[j];

                    if (currentChar == 'S' | currentChar == 's'
                        | currentChar == 'T' | currentChar == 't'
                        | currentChar == 'A' | currentChar == 'a'
                        | currentChar == 'R' | currentChar == 'r')
                    {
                        charCount++;
                    }
                }

                for (int k = 0; k < input.Length; k++)
                {
                    decryptedMessage += (char)(input[k] - charCount);
                }

                string pattern = @"[^@!:>-]*@(?<planetName>[A-Za-z]+)[^@!:>-]*:(?<planetPopulation>\d+)[^@!:>-]*!(?<attackType>[A|D])![^@!:>-]*->(?<soldierCount>\d+)[^@!:>-]*";

                Regex message = new Regex(pattern);

                Match decryptedMess = message.Match(decryptedMessage);

                 if (message.IsMatch(decryptedMessage) == false)
                {
                    continue;
                }

                string planetName = decryptedMess.Groups["planetName"].Value;
                //int planetPopulation = int.Parse(decryptedMess.Groups["planetPopulation"].Value);
                string attackType = decryptedMess.Groups["attackType"].Value;
                // int soldierCount = int.Parse(decryptedMess.Groups["soldierCount"].Value);

                if (attackType == "A")
                {
                    attackedPlanet.Add(planetName);
                    attackedPlanet = attackedPlanet.OrderBy(x=>x).ToList();
                    
                }

                else if (attackType == "D")
                {
                    destroyedPlanet.Add(planetName);
                    destroyedPlanet = destroyedPlanet.OrderBy(x => x).ToList();
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanet.Count}");
            for (int i = 0; i < attackedPlanet.Count; i++)
            {
                Console.Write("-> ");
                Console.WriteLine(attackedPlanet[i]);
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanet.Count}");

            for (int i = 0; i < destroyedPlanet.Count; i++)
            {
                Console.Write("-> ");
                Console.WriteLine(destroyedPlanet[i]);
            }

        }
    }
}
