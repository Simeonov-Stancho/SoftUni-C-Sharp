using System;

namespace CelsiusToFahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            //read
            double celsium = double.Parse(Console.ReadLine());

            //calculate
            double F = (celsium * 9 / 5) + 32;
            
            //write
            Console.WriteLine($"{ F:f2}");
           
        }
    }
}
