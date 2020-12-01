using System;
using System.Collections.Generic;
using System.Linq;

using _03.Raiding.Core.Contracts;
using _03.Raiding.Factories;
using _03.Raiding.IO.Contracts;
using _03.Raiding.Models;

namespace _03.Raiding.Core
{
    public class Engine : IEngine
    {
        private const string WIN_MSG = "Victory!";
        private const string LOSE_MSG = "Defeat...";

        private IReader reader;
        private IWriter writer;
        private readonly HeroFactories heroFactories;
        private readonly ICollection<BaseHero> heroes;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactories = new HeroFactories();
            this.heroes = new List<BaseHero>();
        }

        public void Run()
        {
            FormRaidGroup();
            int bossPower = int.Parse(this.reader.ReadLIne());

            foreach (var hero in heroes)
            {
                this.writer.WriteLine(hero.CastAbility());
            }

            int sumHerosPower = this.heroes.Sum(p => p.Power);

            if (sumHerosPower >= bossPower)
            {
                this.writer.WriteLine(WIN_MSG);
            }

            else
            {
                this.writer.WriteLine(LOSE_MSG);
            }
        }

        private void FormRaidGroup()
        {
            int n = int.Parse(this.reader.ReadLIne());

            while (heroes.Count < n)
            {
                BaseHero hero = null;

                try
                {
                    hero = CreateHero();
                }

                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }

                if (hero != null)
                {
                    this.heroes.Add(hero);
                }
            }
        }

        public BaseHero CreateHero()
        {
            string heroName = Console.ReadLine();
            string heroType = Console.ReadLine();

            BaseHero hero = this.heroFactories.CreateHero(heroName, heroType);
            return hero;
        }
    }
}
