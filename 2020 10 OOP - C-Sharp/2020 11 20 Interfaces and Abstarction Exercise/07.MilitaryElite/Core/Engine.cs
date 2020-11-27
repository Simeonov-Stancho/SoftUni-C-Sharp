using System;
using System.Collections.Generic;
using System.Linq;

using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Core.Contracts;
using _07.MilitaryElite.Enumeration;
using _07.MilitaryElite.Exceptions;
using _07.MilitaryElite.IO.Contracts;
using _07.MilitaryElite.Models;

namespace _07.MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;

        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input;

            while ((input = this.reader.ReadLine()) != "End")
            {
                string[] commandsArg = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string soldierType = commandsArg[0];
                int id = int.Parse(commandsArg[1]);
                string firstName = commandsArg[2];
                string lastName = commandsArg[3];

                ISoldier soldier = null;

                if (soldierType == "Private")
                {
                    soldier = AddPrivate(commandsArg, id, firstName, lastName);
                }

                else if (soldierType == "LieutenantGeneral")
                {
                    soldier = AddGeneral(commandsArg, id, firstName, lastName);
                }

                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(commandsArg[4]);
                    string corps = commandsArg[5];

                    try
                    {
                        soldier = AddEngineer(commandsArg, id, firstName, lastName, salary, corps);
                    }

                    catch (InvalidCorpsException ex)
                    {
                        continue;
                    }
                }

                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(commandsArg[4]);
                    string corps = commandsArg[5];

                    try
                    {
                        ICommando commando = AddCommando(commandsArg, id, firstName, lastName, salary, corps);

                        soldier = commando;
                    }

                    catch (InvalidCorpsException ex)
                    {
                        continue;
                    }
                }

                else if (soldierType == "Spy")
                {
                    soldier = AddSpy(commandsArg, id, firstName, lastName);
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }
            }

            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }

        private static ISoldier AddSpy(string[] commandsArg, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            int codeNumber = int.Parse(commandsArg[4]);
            ISoldier spy = new Spy(id, firstName, lastName, codeNumber);
            soldier = spy;
            return soldier;
        }

        private static ICommando AddCommando(string[] commandsArg, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);

            for (int i = 6; i < commandsArg.Length; i += 2)
            {
                string codeName = commandsArg[i];
                string state = commandsArg[i + 1];

                try
                {
                    IMission missionToAdd = new Mission(codeName, state);
                    commando.AddMission(missionToAdd);
                }

                catch (InvalidStateExceptions ex)
                {
                    continue;
                }
            }

            return commando;
        }

        private static ISoldier AddEngineer(string[] commandsArg, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ISoldier soldier;
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
            for (int i = 6; i < commandsArg.Length; i += 2)
            {
                string repairPart = commandsArg[i];
                int repairHours = int.Parse(commandsArg[i + 1]);
                IRepair repairToAdd = new Repair(repairPart, repairHours);
                engineer.AddRepair(repairToAdd);
            }

            soldier = engineer;
            return soldier;
        }

        private ISoldier AddGeneral(string[] commandsArg, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(commandsArg[4]);
            ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

            foreach (var privateID in commandsArg.Skip(5))
            {
                ISoldier privateToAdd = this.soldiers
                    .First(s => s.Id == int.Parse(privateID));

                general.AddPrivate(privateToAdd);
            }

            soldier = general;
            return soldier;
        }

        private static ISoldier AddPrivate(string[] commandsArg, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(commandsArg[4]);
            soldier = new Private(id, firstName, lastName, salary);
            return soldier;
        }
    }
}
