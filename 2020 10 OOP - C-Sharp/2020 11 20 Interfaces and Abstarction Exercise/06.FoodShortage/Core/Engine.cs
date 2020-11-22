using System;
using System.Collections.Generic;
using System.Linq;

using _06.FoodShortage.Contracts;
using _06.FoodShortage.Models;

namespace _06.FoodShortage.Core
{
    public class Engine
    {
        private readonly List<IBuyer> buyers;

        public Engine()
        {
            this.buyers = new List<IBuyer>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] peopleArg = ReadInput();

                if (peopleArg.Length == 4)
                {
                    AddCitizen(peopleArg);
                }

                else if (peopleArg.Length == 3)
                {
                    AddRebel(peopleArg);
                }
            }

            string buyerName = string.Empty;

            while ((buyerName = Console.ReadLine()) != "End")
            {
                BuyFood(buyerName);
            }

            PrintResult();
        }

        private void PrintResult()
        {
            Console.WriteLine(buyers.Sum(f => f.Food));
        }

        private static string[] ReadInput()
        {
            return Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
        }

        private void BuyFood(string buyerName)
        {
            if (buyers.Any(n => n.Name == buyerName))
            {
                var buyer = buyers.FirstOrDefault(n => n.Name == buyerName);
                buyer.BuyFood();
            }
        }

        private void AddCitizen(string[] peopleArg)
        {
            string name = peopleArg[0];
            int age = int.Parse(peopleArg[1]);
            string id = peopleArg[2];
            string birthdate = peopleArg[3];
            Citizen citizen = new Citizen(name, age, id, birthdate);
            buyers.Add(citizen);
        }

        private void AddRebel(string[] peopleArg)
        {
            string name = peopleArg[0];
            int age = int.Parse(peopleArg[1]);
            string group = peopleArg[2];
            Rebel rebel = new Rebel(name, age, group);
            buyers.Add(rebel);
        }
    }
}