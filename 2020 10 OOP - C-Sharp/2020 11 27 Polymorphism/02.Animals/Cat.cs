namespace Animals
{
    public class Cat : Animal
    {
        private const string CAT_SOUND = "MEEOW";

        public Cat(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {

        }

        public override string ExplainSelf()
        {
            return $"{base.ExplainSelf()} {CAT_SOUND}";
        }
    }
}
