using System;
using System.Collections.Generic;
using System.Linq;

using _05.BirthdayCelebrations.Contracts;
using _05.BirthdayCelebrations.Models;

namespace _05.BirthdayCelebrations.Core
{
    public class Engine
    {
        private readonly List<IBirthable> birthables;

        public Engine()
        {
            this.birthables = new List<IBirthable>();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] visitorInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (visitorInfo[0] == "Citizen")
                {
                    AddCitizen(visitorInfo);
                }

                else if (visitorInfo[0] == "Pet")
                {
                    AddPet(visitorInfo);
                }
            }

            string birthYear = Console.ReadLine();
            PrintResult(birthYear);
        }

        private void AddPet(string[] visitorInfo)
        {
            string name = visitorInfo[1];
            string birthdate = visitorInfo[2];
            Pet pet = new Pet(name, birthdate);
            birthables.Add(pet);
        }

        private void AddCitizen(string[] visitorInfo)
        {
            string name = visitorInfo[1];
            int age = int.Parse(visitorInfo[2]);
            string id = visitorInfo[3];
            string birthdate = visitorInfo[4];
            Citizen citizen = new Citizen(name, age, id, birthdate);
            birthables.Add(citizen);
        }

        private void PrintResult(string birthYear)
        {
            foreach (var birthable in birthables)
            {
                if (birthable.Birthdate.EndsWith(birthYear))
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}