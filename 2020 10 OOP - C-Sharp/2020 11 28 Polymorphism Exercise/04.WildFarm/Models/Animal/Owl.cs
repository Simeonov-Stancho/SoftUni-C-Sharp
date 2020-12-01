using _04.WildFarm.Models.Food.Models;
using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animal
{
    class Owl : Bird
    {
        private const double WEIGHT_MULTIPLIER = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        public override double WeightMultiplier => WEIGHT_MULTIPLIER;

        public override ICollection<Type> PreferedFoods => 
            new List<Type>() { typeof(Meat)};

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
