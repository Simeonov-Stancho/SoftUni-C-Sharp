using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using _05.FootballTeamGenerator.Common;

namespace _05.FootballTeamGenerator.Core
{
    class Engine
    {
        private readonly ICollection<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] commands = input.Split(";").ToArray();

                    if (commands[0] == "Team")
                    {
                        this.AddTeam(commands[1]);
                    }

                    else if (commands[0] == "Add")
                    {
                        this.CheckMissingTeam(commands[1]);

                        this.AddPlayer(commands);
                    }

                    else if (commands[0] == "Remove")
                    {
                        this.RemovePlayer(commands);
                    }

                    else if (commands[0] == "Rating")
                    {
                        this.RatingTeam(commands);
                    }
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void CheckMissingTeam(string teamName)
        {
            Team team = this.teams.FirstOrDefault(n => n.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException(String.Format(GlobalConstants.MISSING_TEAM_EXC_MSG, teamName));
            }
        }

        private void AddTeam(string teamName)
        {
            Team team = new Team(teamName);
            teams.Add(team);
        }

        private void AddPlayer(string[] playerInfo)
        {
            string teamName = playerInfo[1];
            string playerName = playerInfo[2];
            int endurance = int.Parse(playerInfo[3]);
            int sprint = int.Parse(playerInfo[4]);
            int dribble = int.Parse(playerInfo[5]);
            int passing = int.Parse(playerInfo[6]);
            int shooting = int.Parse(playerInfo[7]);

            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            Team team = this.teams.FirstOrDefault(t => t.Name == teamName);
            team.AddPlayer(player);
        }

        private void RemovePlayer(string[] commands)
        {
            Team currentToRemove = teams.FirstOrDefault(n => n.Name == commands[1]);

            currentToRemove.RemovePlayer(commands[2]);
        }

        private void RatingTeam(string[] commands)
        {
            this.CheckMissingTeam(commands[1]);
            Team team = this.teams.FirstOrDefault(n => n.Name == commands[1]);
            Console.WriteLine(team);
        }
    }
}
