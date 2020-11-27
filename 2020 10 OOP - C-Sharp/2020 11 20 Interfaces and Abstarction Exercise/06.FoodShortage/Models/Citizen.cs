using _06.FoodShortage.Contracts;

namespace _06.FoodShortage.Models
{
    public class Citizen : IBuyer
    {
        private const int FOOD_INCREASER = 10;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.Birthdate = birthdate;
            this.Food = Common.GlobalConstants.STARTING_FOOD;
        }

        public string Name { get; }
        public int Age { get; }
        public string ID { get; }
        public string Birthdate { get; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += FOOD_INCREASER;
        }
    }
}