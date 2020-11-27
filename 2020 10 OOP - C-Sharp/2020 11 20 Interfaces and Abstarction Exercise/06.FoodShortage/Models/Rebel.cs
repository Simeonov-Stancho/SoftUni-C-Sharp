using _06.FoodShortage.Contracts;

namespace _06.FoodShortage.Models
{
    public class Rebel:IBuyer
    {
        private const int FOOD_INCREASER = 5;

        private int food;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = Common.GlobalConstants.STARTING_FOOD;
        }

        public string Name { get; }
        public int Age { get; }
        public string Group { get; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += FOOD_INCREASER;
        }
    }
}