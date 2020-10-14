using System;

namespace VetClinic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // Initialize the repository
            Clinic clinic = new Clinic(2);
            Clinic building = new Clinic(1);

            // Initialize entity
            Pet dog = new Pet("Ellias", 5, "Tim");
            Pet cat = new Pet("Ellias", 2, "Mia");
            Pet bunny = new Pet("Zak", 4, "Jon");

            
            clinic.Add(dog);
            building.Add(cat);
            clinic.Add(bunny);
            Console.WriteLine(clinic.Remove("Ellias")); // True
            Console.WriteLine(clinic.Remove("Pufa")); // False

            // Count
            Console.WriteLine(clinic.Count); // 2
            Console.WriteLine(building.Count); // 2


            // Get Pet
            Pet pet = clinic.GetPet("Bella", "Mia");
            Console.WriteLine(pet); // Bella 2 (Mia)

            // Get Oldest Pet
            Pet oldestPet = clinic.GetOldestPet();
            Console.WriteLine(oldestPet); // Zak 4 (Jon)


            

            // Get Statistics
            Console.WriteLine(clinic.GetStatistics());
            //The clinic has the following patients:
            //Bella Mia
            //Zak Jon

        }
    }
}
