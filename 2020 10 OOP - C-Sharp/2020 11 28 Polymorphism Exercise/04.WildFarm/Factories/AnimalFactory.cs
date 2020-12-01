using _04.WildFarm.Models.Animal;

namespace _04.WildFarm.Factories
{
    public class AnimalFactory
    {
        public AnimalFactory()
        {

        }

        public Animal CreateAnimal(string[] arg)
        {
            Animal animal = null;

            string animalType = arg[0];
            string name = arg[1];
            double weight = double.Parse(arg[2]);

            if (animalType == "Cat")
            {
                string livingRegion = arg[3];
                string breed = arg[4];

                animal = new Cat(name, weight, livingRegion, breed);
            }

            else if (animalType == "Tiger")
            {
                string livingRegion = arg[3];
                string breed = arg[4];

                animal = new Tiger(name, weight, livingRegion, breed);
            }

            else if (animalType == "Owl")
            {
                double wingSize = double.Parse(arg[3]);

                animal = new Owl(name, weight, wingSize);
            }

            else if (animalType == "Hen")
            {
                double wingSize = double.Parse(arg[3]);

                animal = new Hen(name, weight, wingSize);
            }

            else if (animalType == "Mouse")
            {
                string livingRegion = arg[3];

                animal = new Mouse(name, weight, livingRegion);
            }

            else if (animalType == "Dog")
            {
                string livingRegion = arg[3];

                animal = new Dog(name, weight, livingRegion);
            }

            return animal;
        }
    }
}
