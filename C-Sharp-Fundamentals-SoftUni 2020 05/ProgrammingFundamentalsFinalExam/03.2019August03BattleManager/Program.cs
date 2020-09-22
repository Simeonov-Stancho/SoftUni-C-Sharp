using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._2019August03BattleManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<int>> playerStats = new Dictionary<string, List<int>>();

            while ((input = Console.ReadLine()) != "Results")
            {
                List<string> commands = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "Add")
                {
                    string personName = commands[1];
                    int health = int.Parse(commands[2]);
                    int energy = int.Parse(commands[3]);

                    if (!playerStats.ContainsKey(personName))
                    {
                        playerStats.Add(personName, new List<int>());
                        playerStats[personName].Add(health);    //0
                        playerStats[personName].Add(energy);    //1
                    }

                    else
                    {
                        playerStats[personName][0] += health;
                    }
                }

                else if (commands[0] == "Attack")
                {
                    string attackerName = commands[1];
                    string defenderName = commands[2];
                    int damage = int.Parse(commands[3]);

                    if (playerStats.ContainsKey(attackerName) && playerStats.ContainsKey(defenderName))
                    {
                        playerStats[defenderName][0] -= damage;
                        playerStats[attackerName][1] -= 1;

                        if (playerStats[defenderName][0] <= 0)
                        {
                            playerStats.Remove(defenderName);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }

                        if (playerStats[attackerName][1] <= 0)
                        {
                            playerStats.Remove(attackerName);
                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                }

                else if (commands[0] == "Delete")
                {
                    string userName = commands[1];

                    if (userName == "All")
                    {
                        playerStats.Clear();
                    }

                    else if (playerStats.ContainsKey(userName))
                    {
                        playerStats.Remove(userName);
                    }
                }

            }

            playerStats = playerStats
                    .OrderByDescending(x => x.Value[0])
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"People count: { playerStats.Count}");

            foreach (var player in playerStats)
            {
                Console.WriteLine($"{player.Key} - {player.Value[0]} - {player.Value[1]}");
            }
        }
    }
}
