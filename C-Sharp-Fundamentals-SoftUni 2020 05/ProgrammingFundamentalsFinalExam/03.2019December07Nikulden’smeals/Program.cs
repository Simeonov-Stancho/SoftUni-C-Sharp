using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._2019December07Nikulden_smeals
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<string>> mealsByGuest = new Dictionary<string, List<string>>();
            int unlikedMeals = 0;

            while ((input = Console.ReadLine())!="Stop")
            {
                List<string> commands = input
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (commands[0] == "Like")
                {
                    string guest = commands[1];
                    string meal = commands[2];

                    if (!mealsByGuest.ContainsKey(guest))
                    {
                        mealsByGuest.Add(guest, new List<string>());
                        mealsByGuest[guest].Add(meal);
                    }

                    else
                    {
                        if (!mealsByGuest[guest].Contains(meal))
                        {
                            mealsByGuest[guest].Add(meal);
                        }
                    }
                }

                else if (commands[0] == "Unlike")
                {
                    string guest = commands[1];
                    string meal = commands[2];

                    if (!mealsByGuest.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }

                    else
                    {
                        if (!mealsByGuest[guest].Contains(meal))
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                            continue;
                        }

                        mealsByGuest[guest].Remove(meal);
                        unlikedMeals++;
                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                    }

                }
            }

            mealsByGuest = mealsByGuest
                            .OrderByDescending(x => x.Value.Count)
                            .ThenBy(x => x.Key)
                            .ToDictionary(x => x.Key, x => x.Value);

            foreach (var guest in mealsByGuest)
            {
                Console.Write($"{guest.Key}: ");
                Console.Write(string.Join(", ", guest.Value));
                Console.WriteLine();
            }

            Console.WriteLine($"Unliked meals: {unlikedMeals}");
        }
    }
}
