using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedPersons = new SortedSet<Person>();
            HashSet<Person> persons = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Person currPerson = new Person(personInfo[0], int.Parse(personInfo[1]));
                sortedPersons.Add(currPerson);
                persons.Add(currPerson);
            }

            Console.WriteLine(sortedPersons.Count);
            Console.WriteLine(persons.Count);
        }
    }
}