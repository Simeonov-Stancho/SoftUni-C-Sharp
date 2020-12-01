using _04.WildFarm.Models.Food.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Factories
{
    public class FoodFactory
    {
        public FoodFactory()
        {

        }

        public Food CreateFood(string[] foodArg)
        {
            Food food = null;

            string foodType = foodArg[0];
            int quantity = int.Parse(foodArg[1]);

            if (foodType == "Fruit")
            {
                food = new Fruit(quantity);
            }

            else if (foodType == "Meat")
            {
                food = new Meat(quantity);
            }

            else if (foodType == "Seeds")
            {
                food = new Seeds(quantity);
            }

            else if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }

            return food;
        }
    }
}
