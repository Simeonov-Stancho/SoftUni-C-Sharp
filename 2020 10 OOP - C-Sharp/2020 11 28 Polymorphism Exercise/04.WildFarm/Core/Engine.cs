using _04.WildFarm.Core.Contracts;
using _04.WildFarm.Factories;
using _04.WildFarm.IO.Contracts;
using _04.WildFarm.Models.Animal;
using _04.WildFarm.Models.Food.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.WildFarm.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;
        private ICollection<Animal> animals;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string input;
            Animal animal = null;
            Food food = null;

            while ((input = this.reader.ReadLine()) != "End")
            {
                animal = CreateAnimal(input);
                animals.Add(animal);

                string[] foodArg = this.reader.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                food = foodFactory.CreateFood(foodArg);

                this.writer.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Feed(food);
                }

                catch (InvalidOperationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }

            foreach (var currentAnimal in animals)
            {
                this.writer.WriteLine(currentAnimal.ToString());
            }
        }

        private Animal CreateAnimal(string input)
        {
            Animal animal;
            string[] animalArg = input
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

            animal = animalFactory.CreateAnimal(animalArg);
            return animal;
        }
    }
}
