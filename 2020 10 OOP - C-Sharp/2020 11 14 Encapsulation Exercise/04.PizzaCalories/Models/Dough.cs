using System;
using System.Collections.Generic;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private readonly Dictionary<string, double> DEFAULT_FLOUR_TYPE_MODIFIER =
             new Dictionary<string, double>
        {
            {"white", 1.5 },
            { "wholegrain", 1.0 }
        };

        private readonly Dictionary<string, double> DEFAULT_BAKING_TECHINIQUE_MODIFIER =
                     new Dictionary<string, double>
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };
        private const string INVALID_TYPE_OF_DOUGH_EXC_MSG = "Invalid type of dough.";
        private const string INVALID_WEIGHT_OF_DOUGH_EXC_MSG = "Dough weight should be in the range [1..200].";
        private const double MIN_WEIGHT = 1;
        private const double MAX_WEIGHT = 200;
        private const double BASE_CALORIES_PER_GRAMS = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return this.flourType; }

            private set
            {
                if (!this.DEFAULT_FLOUR_TYPE_MODIFIER.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(INVALID_TYPE_OF_DOUGH_EXC_MSG);
                }

                this.flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }

            private set
            {
                if (!DEFAULT_BAKING_TECHINIQUE_MODIFIER.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(INVALID_TYPE_OF_DOUGH_EXC_MSG);
                }

                this.bakingTechnique = value.ToLower();
            }
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < MIN_WEIGHT || value > MAX_WEIGHT)
                {
                    throw new ArgumentException(INVALID_WEIGHT_OF_DOUGH_EXC_MSG);
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double doughCalories = BASE_CALORIES_PER_GRAMS
                              * this.Weight
                              * this.DEFAULT_FLOUR_TYPE_MODIFIER[this.FlourType]
                              * this.DEFAULT_BAKING_TECHINIQUE_MODIFIER[this.BakingTechnique];
            return doughCalories;
        }
    }
}
