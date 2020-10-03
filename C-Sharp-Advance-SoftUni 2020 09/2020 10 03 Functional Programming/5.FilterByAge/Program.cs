using System;
using System.Collections.Generic;
using System.Linq;


namespace _5.FilterByAge
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] persons = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] currentPerson = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                persons[i] = new Person
                {
                    Name = currentPerson[0],
                    Age = int.Parse(currentPerson[1])
                };
            }

            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> conditionDelegate = GetCondition(condition, ageFilter);
            Action<Person> printerDelegate = Printer(format);

            foreach (var person in persons)
            {
                if (conditionDelegate(person))
                {
                    printerDelegate(person);
                }
            }
        }

        static Func<Person, bool> GetCondition(string condition, int age)
        {
            if (condition == "younger")
            {
                return p => p.Age < age;
            }

            else if (condition == "older")
            {
                return p => p.Age >= age;
            }

            else
            {
                return null;
            }
        }

        static Action<Person> Printer(string format)
        {
            if (format == "name")
            {
                return p => { Console.WriteLine($"{p.Name}"); };
            }

            else if (format == "age")
            {
                return p => { Console.WriteLine($"{p.Age}"); };
            }

            else if (format == "name age")
            {
                return p => { Console.WriteLine($"{p.Name} - {p.Age}"); }; ;
            }

            else
            {
                return null;
            }
        }
    }
}