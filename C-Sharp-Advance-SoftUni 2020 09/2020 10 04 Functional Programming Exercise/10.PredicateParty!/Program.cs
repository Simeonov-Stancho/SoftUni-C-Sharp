using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                string commandType = command[0];
                string criteriaType = command[1];
                string checkCriteria = command[2];

                Predicate<string> predicate = GetPredicate(criteriaType, checkCriteria);

                guests = ReturnGuestsList(guests, command, predicate);
            }

            if (guests.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
                return;
            }

            Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
        }

        static List<string> ReturnGuestsList(List<string> guests, string[] command, Predicate<string> predicate)
        {
            if (command[0] == "Double")
            {
                for (int i = 0; i < guests.Count; i++)
                {
                    if (predicate(guests[i]))
                    {
                        guests.Insert(i + 1, guests[i]);
                        i++;
                    }
                }
            }

            else if (command[0] == "Remove")
            {
                guests.RemoveAll(predicate);
            }

            return guests;
        }

        static Predicate<string> GetPredicate(string criteriaType, string checkCriteria)
        {
            Predicate<string> predicate = null;

            if (criteriaType == "StartsWith")
            {
                predicate = x => x.StartsWith(checkCriteria);
            }

            else if (criteriaType == "EndsWith")
            {
                predicate = x => x.EndsWith(checkCriteria);
            }

            else if (criteriaType == "Length")
            {
                predicate = x => x.Length == int.Parse(checkCriteria);
            }

            return predicate;
        }
    }
}
