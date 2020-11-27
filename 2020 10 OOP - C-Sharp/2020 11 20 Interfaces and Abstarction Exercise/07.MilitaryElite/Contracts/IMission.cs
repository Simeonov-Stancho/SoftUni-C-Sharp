using _07.MilitaryElite.Enumeration;

namespace _07.MilitaryElite.Contracts
{
    public interface IMission
    {
        public string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
