using System;

namespace TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            //read
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            //calculate
            double area = a * h / 2;
            
            //write
            Console.WriteLine($"{ area:f2}");
            
        }
    }
}
