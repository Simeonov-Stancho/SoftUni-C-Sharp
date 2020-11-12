using System;

namespace _05CareofPuppy
{
    class Program
    {
        static void Main(string[] args)
        {
            double food = int.Parse(Console.ReadLine());  //kg
            string eatedFood = Console.ReadLine(); //g

            double totalFood = 0;

            while (eatedFood != "Adopted")
            {
                double eated = double.Parse(eatedFood);
                totalFood += eated;

                eatedFood = Console.ReadLine();
            }
            if (totalFood <= food * 1000)
            {
                Console.WriteLine($"Food is enough! Leftovers: {food * 1000 - totalFood} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {totalFood - food * 1000} grams more.");
            }
        }
    }
}
