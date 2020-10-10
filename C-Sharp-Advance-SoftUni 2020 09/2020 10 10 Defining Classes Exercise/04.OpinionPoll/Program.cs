using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            persons = AddPerson(n, persons);

            List<Person> opinionPoll = persons.Where(x => (x.Age > 30))
                                              .OrderBy(x => x.Name).ToList();

            foreach (var person in opinionPoll)
            {
                Console.WriteLine($"{person.Name } - {person.Age }");
            }
        }

        static List<Person> AddPerson(int n, List<Person> person)
        {
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = input[0];
                int age = int.Parse(input[1]);
                Person currentPerson = new Person(name, age);
                person.Add(currentPerson);
            }

            return person;
        }
    }
}
