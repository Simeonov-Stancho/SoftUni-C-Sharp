using System;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string biggestKeg = "";
            double maxVolume = 0;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = (Math.PI) * (radius * radius) * (height * 1.0);

                if (volume >= maxVolume)
                {
                    biggestKeg = model;
                    maxVolume = volume;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
