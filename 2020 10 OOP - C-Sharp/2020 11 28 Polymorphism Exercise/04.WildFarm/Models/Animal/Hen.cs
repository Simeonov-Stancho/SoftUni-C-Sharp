using _04.WildFarm.Models.Food.Models;
using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animal
{
    public class Hen : Bird
    {
        private const double WEIGHT_MULTIPLIER = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;

        public override ICollection<Type> PreferedFoods => 
            new List<Type>() { typeof(Vegetable), typeof(Fruit), typeof(Meat), 
                                typeof(Seeds) };

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
