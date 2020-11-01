using System;

namespace CircleAreaPerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            //read
            double r = double.Parse(Console.ReadLine());

            //calculate
            double area = Math.PI * r * r;
            double perimeter = 2 * Math.PI * r;

            //write
            
            Console.WriteLine($"{ area:f2}");
            Console.WriteLine($"{ perimeter:f2}");
        }
    }
}
