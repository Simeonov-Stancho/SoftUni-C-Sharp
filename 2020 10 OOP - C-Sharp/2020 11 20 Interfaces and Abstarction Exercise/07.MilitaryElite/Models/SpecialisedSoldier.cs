using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enumeration;
using _07.MilitaryElite.Exceptions;
using System;
using System.Collections.Generic;

namespace _07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private ICollection<ISpecialisedSoldier> privates;

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string corpsStr)
        {

            bool parsed = Enum.TryParse<Corps>(corpsStr, out Corps corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            return corps;
        }
    }
}
