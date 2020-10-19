using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.Data = new List<Hero>();
        }

        public List<Hero> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            this.data.RemoveAll(h => h.Name == name);
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero heroWithHighestStrength = this.data.OrderByDescending(h => h.Item.Strength)
                            .First();

            return heroWithHighestStrength;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero heroWithHighestAbility = this.data.OrderByDescending(h => h.Item.Ability)
                            .First();

            return heroWithHighestAbility;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero heroWithHighestIntelligence = this.data.OrderByDescending(h => h.Item.Intelligence)
                            .First();

            return heroWithHighestIntelligence;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in data)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}