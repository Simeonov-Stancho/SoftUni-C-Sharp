using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PizzaCalories.Models;

namespace PizzaCalories.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            try
            {
                string[] pizzaInfo = ReadingInput();
                Dough dough = CreateDough();
                Pizza pizza = CreatePizza(pizzaInfo, dough);
                AddingTopping(pizza);
                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static Dough CreateDough()
        {
            string[] inputInfo = ReadingInput();

            string flourType = inputInfo[1];
            string bakingTechnique = inputInfo[2];
            double weight = double.Parse(inputInfo[3]);
            Dough dough = new Dough(flourType, bakingTechnique, weight);
            return dough;
        }

        private static Pizza CreatePizza(string[] pizzaInfo, Dough dough)
        {
            string pizzaName = pizzaInfo[1];
            return new Pizza(pizzaName, dough);
        }

        private static string[] ReadingInput()
        {
            string[] inputInfo = Console.ReadLine()
                                .Split(" ")
                                .ToArray();
            return inputInfo;
        }

        private static void AddingTopping(Pizza pizza)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] toppingInfo = input
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

                string toppingType = toppingInfo[1];
                double toppingWeight = double.Parse(toppingInfo[2]);

                Topping topping = new Topping(toppingType, toppingWeight);
                pizza.AddTopping(topping);
            }
        }

    }
}
