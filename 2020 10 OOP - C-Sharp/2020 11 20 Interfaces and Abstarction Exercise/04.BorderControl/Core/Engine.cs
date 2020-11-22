using System;
using System.Collections.Generic;
using System.Linq;

using _04.BorderControl.Contracts;
using _04.BorderControl.Models;

namespace _04.BorderControl.Core
{
    public class Engine
    {
        private readonly List<IInhabitable> inhabitants;

        public Engine()
        {
            this.inhabitants = new List<IInhabitable>();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] visitorInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (visitorInfo.Length == 3)
                {
                    EnterCitizen(visitorInfo);
                }

                else
                {
                    EnterRobot(visitorInfo);
                }
            }

            string fakeID = Console.ReadLine();

            foreach (var inhabitant in inhabitants)
            {
                if (inhabitant.ID.EndsWith(fakeID))
                {
                    Console.WriteLine(inhabitant.ID);
                }
            }
        }
        
        private void EnterCitizen(string[] visitorInfo)
        {
            string name = visitorInfo[0];
            int age = int.Parse(visitorInfo[1]);
            string id = visitorInfo[2];
            Citizen citizen = new Citizen(name, age, id);
            inhabitants.Add(citizen);
        }

        private void EnterRobot(string[] visitorInfo)
        {
            string model = visitorInfo[0];
            string id = visitorInfo[1];
            Robot robot = new Robot(model, id);
            inhabitants.Add(robot);
        }
    }
}