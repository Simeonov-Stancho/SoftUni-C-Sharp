namespace _03.Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int ROGUE_POWER = 80;

        public Rogue(string name) : base(name)
        {
            this.Power = ROGUE_POWER;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
