using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._2020April04HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();
            for (int i = 0; i < n; i++)
            {
                List<string> input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string heroName = input[0];
                int hp = int.Parse(input[1]);   //0
                int mp = int.Parse(input[2]);   //1

                heroes.Add(heroName, new List<int>());
                heroes[heroName].Add(hp);
                heroes[heroName].Add(mp);
            }

            string text = string.Empty;

            while ((text = Console.ReadLine()) != "End")
            {
                List<string> commands = text
                         .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                         .ToList();

                if (commands[0] == "CastSpell")
                {
                    string currentHeroName = commands[1];
                    int mpNeeded = int.Parse(commands[2]);
                    string spellName = commands[3];
                    int currentMP = heroes[currentHeroName][1];

                    if (currentMP < mpNeeded)
                    {
                        Console.WriteLine($"{currentHeroName} does not have enough MP to cast {spellName}!");
                        continue;
                    }
                    currentMP -= mpNeeded;
                    heroes[currentHeroName][1] = currentMP;
                    Console.WriteLine($"{currentHeroName} has successfully cast {spellName} and now has {currentMP} MP!");
                }

                else if (commands[0] == "TakeDamage")
                {
                    string currentHeroName = commands[1];
                    int damage = int.Parse(commands[2]);
                    string attacker = commands[3];
                    int currentHP = heroes[currentHeroName][0];

                    currentHP -= damage;
                    heroes[currentHeroName][0] = currentHP;

                    if (currentHP <= 0)
                    {
                        Console.WriteLine($"{currentHeroName} has been killed by {attacker}!");
                        heroes.Remove(currentHeroName);
                        continue;
                    }

                    Console.WriteLine($"{currentHeroName} was hit for {damage} HP by {attacker} and now has {currentHP} HP left!");
                }

                else if (commands[0] == "Recharge")
                {
                    string currentHeroName = commands[1];
                    int amount = int.Parse(commands[2]);
                    int currentMP = heroes[currentHeroName][1];

                    if ((amount + currentMP) > 200)
                    {
                        amount = 200 - currentMP;
                    }
                    heroes[currentHeroName][1] += amount;

                    Console.WriteLine($"{currentHeroName} recharged for {amount} MP!");
                }

                else if (commands[0] == "Heal")
                {
                    string currentHeroName = commands[1];
                    int amount = int.Parse(commands[2]);
                    int currentHP = heroes[currentHeroName][0];

                    if ((amount + currentHP) > 100)
                    {
                        amount = 100 - currentHP;
                    }
                    heroes[currentHeroName][0] += amount;

                    Console.WriteLine($"{currentHeroName} healed for {amount} HP!");
                }
            }

            heroes = heroes
                .OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value[0]}");
                Console.WriteLine($"  MP: {hero.Value[1]}");
            }
        }
    }
}
