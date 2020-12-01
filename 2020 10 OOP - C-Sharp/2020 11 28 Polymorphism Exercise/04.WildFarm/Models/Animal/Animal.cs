using _04.WildFarm.Models.Food.Contracts;
using _04.WildFarm.Models.Food.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animal
{
    public abstract class Animal
    {
        private const string UnPreferedFoodMsg = "{0} does not eat {1}!";
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        public abstract ICollection<Type> PreferedFoods { get; }

        public abstract string ProduceSound();

        public void Feed(IFood food)
        {
            if (!this.PreferedFoods.Contains(food.GetType()))
            {
                throw new InvalidOperationException(string.Format(UnPreferedFoodMsg, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }
    }
}
