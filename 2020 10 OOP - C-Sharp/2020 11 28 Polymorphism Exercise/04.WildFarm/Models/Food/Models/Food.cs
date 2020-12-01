using _04.WildFarm.Models.Food.Contracts;

namespace _04.WildFarm.Models.Food.Models
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
