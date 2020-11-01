using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Roster = new List<Player>();
        }

        public List<Player> Roster
        {
            get { return roster; }
            set { this.roster = value; }
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return this.roster.Count; }
        }

        public void AddPlayer(Player player)
        {
            if (this.Capacity > this.Roster.Count)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            bool isExist = roster.Exists(p => p.Name == name);
            if (isExist)
            {
                roster.RemoveAll(p => p.Name == name);
            }

            return isExist;
        }

        public void PromotePlayer(string name)
        {
            foreach (var player in roster)
            {
                if (player.Name == name)
                {
                    if (player.Rank != "Member")
                    {
                        player.Rank = "Member";
                        break;
                    }
                }
            }
        }

        public void DemotePlayer(string name)
        {
            foreach (var player in roster)
            {
                if (player.Name == name)
                {
                    if (player.Rank != "Trial")
                    {
                        player.Rank = "Trial";
                        break;
                    }
                }
            }
        }

        public Player[] KickPlayersByClass(string classID)
        {
            Player[] kickedPlayers = this.roster.Where(p => p.Class == classID)
                                           .ToArray();
            roster.RemoveAll(p => p.Class == classID);
            return kickedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            if (roster.Count > 0)
            {
                foreach (var player in roster)
                {
                    sb.AppendLine(player.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
