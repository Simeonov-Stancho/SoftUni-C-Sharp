using System;

namespace TrapeziodArea
{
    class Program
    {
        static void Main(string[] args)
        {

            //read
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            //calculate
            double area = (b1 + b2) * h / 2;

            //write
            Console.WriteLine($"{area:f2}");

                       
        }
    }
}
