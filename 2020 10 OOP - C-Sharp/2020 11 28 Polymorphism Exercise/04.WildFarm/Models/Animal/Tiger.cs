using _04.WildFarm.Models.Food.Models;
using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animal
{
    public class Tiger : Feline
    {
        private const double WEIGHT_MULTIPLIER = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {

        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;

        public override ICollection<Type> PreferedFoods => 
            new List<Type>() { typeof(Meat)};

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
