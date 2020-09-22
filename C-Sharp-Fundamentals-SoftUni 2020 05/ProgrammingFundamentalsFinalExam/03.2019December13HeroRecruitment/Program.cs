using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._2019December13HeroRecruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "End")
            {
                List<string> commads = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commads[0] == "Enroll")
                {
                    string heroName = commads[1];

                    if (!heroes.ContainsKey(heroName))
                    {
                        heroes.Add(heroName, new List<string>());
                    }

                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }

                else if (commads[0] == "Learn")
                {
                    string heroName = commads[1];
                    string spellName = commads[2];

                    if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }

                    else
                    {
                        if (heroes[heroName].Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} has already learnt {spellName}.");
                        }

                        else
                        {
                            heroes[heroName].Add(spellName);
                        }
                    }
                }

                else if (commads[0] == "Unlearn")
                {
                    string heroName = commads[1];
                    string spellName = commads[2];

                    if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }

                    else
                    {
                        if (!heroes[heroName].Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} doesn't know {spellName}.");
                        }

                        else
                        {
                            heroes[heroName].Remove(spellName);
                        }
                    }
                }
            }

            heroes = heroes
                    .OrderByDescending(x => x.Value.Count)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Heroes:");

            foreach (var hero in heroes)
            {
                Console.Write($"== {hero.Key}: ");
                Console.Write(string.Join(", ", hero.Value));
                Console.WriteLine();
            }
        }
    }
}
