using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Person> persons = new List<Person>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] personInfo = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                Person currentPerson = new Person(personInfo[0],
                                                    int.Parse(personInfo[1]),
                                                    personInfo[2]);
                persons.Add(currentPerson);
            }

            int n = int.Parse(Console.ReadLine());

            Person comparedPerson = persons[n - 1];

            int matchCount = 0;

            foreach (var person in persons)
            {
                if (person.CompareTo(comparedPerson) == 0)
                {
                    matchCount++;
                }
            }

            if (matchCount == 1)
            {
                Console.WriteLine("No matches");
            }

            else
            {
                Console.WriteLine($"{ matchCount} {persons.Count - matchCount} {persons.Count}");
            }
        }
    }
}
