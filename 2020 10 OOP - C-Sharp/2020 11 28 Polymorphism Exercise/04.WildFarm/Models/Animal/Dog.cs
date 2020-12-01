using _04.WildFarm.Models.Food.Models;
using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animal
{
    public class Dog : Mammal
    {
        private const double WEIGHT_MULTIPLIER = 0.40;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {

        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;

        public override ICollection<Type> PreferedFoods => 
            new List<Type>() { typeof(Meat)};

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
