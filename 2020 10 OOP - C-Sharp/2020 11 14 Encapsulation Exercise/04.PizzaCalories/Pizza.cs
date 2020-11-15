using System;
using System.Collections.Generic;
using System.Text;

using PizzaCalories.Models;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MAX_PIZZA_NAME_LENGTH = 15;
        private const string INVALID_PIZZA_NAME_EXC_MSG = "Pizza name should be between 1 and 15 symbols.";
        private const string INVALID_NUMBER_OF_TOPPINGS_EXC_MSG = "Number of toppings should be in range [0..10].";
        private const int MIN_NUMBER_OF_TOPPINGS = 0;
        private const double MAX_NUMBER_OF_TOPPINGS = 10;

        private string name;
        private Dough dough;
        private readonly List<Topping> toppings;

        public Pizza()
        {
            this.toppings = new List<Topping>();
        }

        public Pizza(string name) 
            : this()
        {
            this.Name = name;
        }

        public Pizza(string name, Dough dough) 
            : this(name)
        {
            this.Dough = dough;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)
                 || value.Length > MAX_PIZZA_NAME_LENGTH)
                {
                    throw new ArgumentException(INVALID_PIZZA_NAME_EXC_MSG);
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            private set { this.dough = value; }
        }

        public IReadOnlyCollection<Topping> Topping => this.toppings;

        public void AddTopping(Topping topping)
        {
            if (toppings.Count < MIN_NUMBER_OF_TOPPINGS ||
                toppings.Count > MAX_NUMBER_OF_TOPPINGS)
            {
                throw new ArgumentException(INVALID_NUMBER_OF_TOPPINGS_EXC_MSG);
            }

            this.toppings.Add(topping);
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = this.dough.CalculateCalories();

            foreach (Topping currentTopping in toppings)
            {
                totalCalories += currentTopping.CalculateCalories();
            }

            return totalCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.CalculateTotalCalories():F2} Calories."; ;
        }
    }
}
