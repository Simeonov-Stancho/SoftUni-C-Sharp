using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<People> peoples = new List<People>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = command[0];
                int id = int.Parse(command[1]);
                int age = int.Parse(command[2]);

                People people = new People(name, id, age);
                peoples.Add(people);
            }

            Console.WriteLine(string.Join(Environment.NewLine, peoples.OrderBy(x => x.Age)));
        }

        public class People
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public int Age { get; set; }

            public People(string name, int id, int age)
            {
                this.Name = name;
                this.ID = id;
                this.Age = age;
            }

            public override string ToString()
            {
                return $"{Name} with ID: {ID} is {Age} years old.";
            }
        }
    }
}
