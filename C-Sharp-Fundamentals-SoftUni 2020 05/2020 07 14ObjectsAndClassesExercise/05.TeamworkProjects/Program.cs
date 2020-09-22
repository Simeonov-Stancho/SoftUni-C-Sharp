using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _05.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamCount = int.Parse(Console.ReadLine());

            List<Teams> teams = new List<Teams>();

            for (int i = 0; i < teamCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string creator = input[0];
                string teamName = input[1];

                Teams team = new Teams(creator, teamName);

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(x => x.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                if (!teams.Contains(team))
                {
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {input[0]}!");
                }
            }
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] comands = command
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string member = comands[0];
                string teamName = comands[1];

                if (!teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (teams.Any(x => x.members.Contains(member)) ||
                    teams.Any(x => x.Creator == member && x.TeamName == teamName))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                    continue;
                }

                int index = teams.FindIndex(x => x.TeamName == teamName);
                teams[index].members.Add(member);
            }

            foreach (var teamName in teams.Where(x => x.members.Count > 0)
                .OrderByDescending(x => x.members.Count)
                .ThenBy(x => x.TeamName))
            {
                Console.WriteLine(teamName.ToString());
            }

            var teamsToBeDisbanded = teams.FindAll(x => x.members.Count == 0).OrderBy(x => x.TeamName).ToList();
            Console.WriteLine("Teams to disband:");
            foreach (var teamName in teamsToBeDisbanded)
            {
                Console.WriteLine(teamName.TeamName);
            }
        }

        public class Teams
        {
            public string Creator { get; set; }
            public string TeamName { get; set; }

            public List<string> members;

            public Teams(string creator, string teamName)
            {
                members = new List<string>();
                this.Creator = creator;
                this.TeamName = teamName;
            }

            public override string ToString()
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(TeamName);
                stringBuilder.AppendLine("- " + Creator);

                foreach (var members in members.OrderBy(x => x))
                {
                    stringBuilder.AppendLine("-- " + members);
                }
                return stringBuilder.ToString().TrimEnd();
            }
        }
    }
}
