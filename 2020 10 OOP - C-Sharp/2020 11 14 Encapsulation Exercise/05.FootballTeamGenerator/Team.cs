using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using _05.FootballTeamGenerator.Common;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private const string MISSING_PLAYER_EXC_MSG = "Player {0} is not in {1} team.";

        private string name;
        private readonly ICollection<Player> players;
        //private int rating;

        private Team()
        {
            this.players = new List<Player>();
        }

        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.INVALID_NAME_EXC_MSG);
                }

                this.name = value;
            }
        }

        public IReadOnlyCollection<Player> Players
        {
            get { return (IReadOnlyCollection<Player>)this.players; }
        }

        public double Rating => this.players.Count > 0 
            ? (int)Math.Round(this.players.Average(p => p.SkillLevel))
            :0;

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player playerToRemove = this.players.FirstOrDefault(n => n.Name == name);
            if (playerToRemove == null)
            {
                throw new ArgumentException(String.Format(MISSING_PLAYER_EXC_MSG, name, this.Name));
            }

            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
