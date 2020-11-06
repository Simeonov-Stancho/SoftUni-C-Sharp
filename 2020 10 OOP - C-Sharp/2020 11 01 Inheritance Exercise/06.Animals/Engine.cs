using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Engine
    {
        public void GenerateAnimal()
        {
            List<Animal> animals = new List<Animal>();
            string input;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string typeOfAnimal = input;
                string[] animalInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                if (!CheckIsValidAnimal(name, age, gender))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                Animal currentAnimal = CreatingAnimal(typeOfAnimal, name, age, gender);
                animals.Add(currentAnimal);
            }

            foreach (var currentAnimal in animals)
            {
                Console.WriteLine(currentAnimal.ToString());
            }
        }

        private static bool CheckIsValidAnimal(string name, int age, string gender)
        {
            bool isValidInput = true;
            if ((string.IsNullOrWhiteSpace(name)) ||
                   (age <= 0) ||
                   (gender != "Male" && gender != "Female"))
            {
                isValidInput = false;
            }

            return isValidInput;
        }

        private static Animal CreatingAnimal(string typeOfAnimal, string name, int age, string gender)
        {
            Animal currentAnimal = null;

            if (typeOfAnimal == "Cat")
            {
                currentAnimal = new Cat(name, age, gender);
            }

            else if (typeOfAnimal == "Dog")
            {
                currentAnimal = new Dog(name, age, gender);
            }

            else if (typeOfAnimal == "Frog")
            {
                currentAnimal = new Frog(name, age, gender);
            }

            else if (typeOfAnimal == "Kitten")
            {
                currentAnimal = new Kitten(name, age);
            }

            else if (typeOfAnimal == "Tomcat")
            {
                currentAnimal = new Tomcat(name, age);
            }

            return currentAnimal;
        }
    }
}

