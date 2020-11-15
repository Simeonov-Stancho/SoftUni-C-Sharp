using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private readonly Dictionary<string, double> DEFAULT_TOPPING_TYPE_MODIFIER =
             new Dictionary<string, double>
        {
            {"meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1},
            { "sauce", 0.9}
        };
        private const double BASE_CALORIES_PER_GRAMS = 2;
        private const double MIN_TOPPING_WEIGHT = 1;
        private const double MAX_TOPPING_WEIGHT = 50;

        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get { return this.toppingType; }
            private set
            {
                if (!this.DEFAULT_TOPPING_TYPE_MODIFIER.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {ReturnToppingTypeForPrint(value)} on top of your pizza.");
                }

                this.toppingType = value.ToLower();
            }
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < MIN_TOPPING_WEIGHT || value > MAX_TOPPING_WEIGHT)
                {
                    throw new ArgumentException($"{ReturnToppingTypeForPrint(this.ToppingType)} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double toppingCalories = this.Weight
                                    * BASE_CALORIES_PER_GRAMS
                                    * this.DEFAULT_TOPPING_TYPE_MODIFIER[this.ToppingType];
            return toppingCalories;
        }

        private string ReturnToppingTypeForPrint(string toppingType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(toppingType.First().ToString().ToUpper())
              .Append(toppingType.Substring(1));
            return sb.ToString().TrimEnd();
        }
    }
}
