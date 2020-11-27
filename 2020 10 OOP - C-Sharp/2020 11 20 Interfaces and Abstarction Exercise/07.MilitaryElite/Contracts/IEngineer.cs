using System.Collections.Generic;

namespace _07.MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IRepair> Repairs{ get;  }

        void AddRepair(IRepair repair);
        
    }
}
