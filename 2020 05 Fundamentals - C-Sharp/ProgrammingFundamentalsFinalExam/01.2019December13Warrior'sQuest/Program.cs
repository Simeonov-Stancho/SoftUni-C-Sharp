using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace _01._2019December13Warrior_sQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "For Azeroth")
            {
                List<string> commands = input
                    .Split(" ")
                    .ToList();

                if (commands[0] == "GladiatorStance")
                {
                    skill = skill.ToUpper();
                    Console.WriteLine(skill);
                }

                else if (commands[0] == "DefensiveStance")
                {
                    skill = skill.ToLower();
                    Console.WriteLine(skill);
                }

                else if (commands[0] == "Dispel")
                {
                    int index = int.Parse(commands[1]);
                    string letter = commands[2];

                    if (index < 0 || index >= skill.Length)
                    {
                        Console.WriteLine("Dispel too weak.");
                    }

                    else
                    {
                        skill = skill.Remove(index, letter.Length).Insert(index, letter);
                        Console.WriteLine("Success!");
                    }
                }

                else if (commands[1] == "Change")
                {
                    string substring = commands[2];
                    string secondSubstring = commands[3];

                    if (skill.Contains(substring))
                    {
                        skill = skill.Replace(substring, secondSubstring);
                        Console.WriteLine(skill);
                    }
                }

                else if (commands[1] == "Remove")
                {
                    string substring = commands[2];
                    for (int i = 0; i < skill.Length; i++)
                    {
                        if (skill.Contains(substring))
                        {
                            int index = skill.IndexOf(substring);
                            skill = skill.Remove(index, substring.Length);
                        }
                    }

                    Console.WriteLine(skill);
                }

                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }
            }
        }
    }
}
