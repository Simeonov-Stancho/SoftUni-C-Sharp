namespace Animals
{
    public class Dog : Animal
    {
        private const string DOG_SOUND = "DJAAF";

        public Dog(string name, string favouriteFood)
            : base(name, favouriteFood)
        {

        }

        public override string ExplainSelf()
        {
            return $"{base.ExplainSelf()} {DOG_SOUND}";
        }
    }
}