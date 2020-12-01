using _03.Raiding.Common.Exceptions;
using _03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Factories
{
    public class HeroFactories
    {
        private const string INVALID_HERO = "Invalid hero!";

        public HeroFactories()
        {

        }

        public BaseHero CreateHero(string name, string heroType)
        {
            BaseHero hero = null;

            if (heroType == "Druid")
            {
                hero = new Druid(name);
            }

            else if (heroType == "Paladin")
            {
                hero = new Paladin(name);
            }

            else if (heroType == "Rogue")
            {
                hero = new Rogue(name);
            }

            else if (heroType =="Warrior")
            {
                hero = new Warrior(name);
            }

            else
            {
                throw new Exceptions(INVALID_HERO);
            }

            return hero;
        }
    }
}
