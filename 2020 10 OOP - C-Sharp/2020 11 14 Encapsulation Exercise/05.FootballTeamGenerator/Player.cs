using System;
using System.Collections.Generic;
using System.Text;

using _05.FootballTeamGenerator.Common;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private const int MIN_STAT = 0;
        private const int MAX_STAT = 100;
        private const double STATS_COUNT = 5;
        private const string INVALID_STATS_EXC_MSG = "{0} should be between {1} and {2}.";

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
       
        public Player(string name)
        {
            this.Name = name;
        }

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
            : this(name)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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

        public int Endurance
        {
            get { return this.endurance; }
            private set
            {
                CheckStats(value, nameof(Endurance));

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get { return this.sprint; }
            private set
            {
                CheckStats(value, nameof(Sprint));

                this.sprint = value;
            }
        }
        public int Dribble
        {
            get { return this.dribble; }
            private set
            {
                CheckStats(value, nameof(Dribble));

                this.dribble = value;
            }
        }
        public int Passing
        {
            get { return this.passing; }
            private set
            {
                CheckStats(value, nameof(Passing));

                this.passing = value;
            }
        }
        public int Shooting
        {
            get { return this.shooting; }
            private set
            {
                CheckStats(value, nameof(Shooting));

                this.shooting = value;
            }
        }

        public double SkillLevel => this.CalculateStats();
        
        private void CheckStats(int value, string name)
        {
            if (value < MIN_STAT || value > MAX_STAT)
            {
                throw new ArgumentException(String.Format(INVALID_STATS_EXC_MSG, name, MIN_STAT, MAX_STAT));
            }
        }

        private double CalculateStats()
        {
            double averageStats = (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / STATS_COUNT;
            return averageStats; ;
        }
    }
}
