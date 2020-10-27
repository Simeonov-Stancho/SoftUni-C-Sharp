using System;

namespace _2DRectangleArea1
{
    class Program
    {
        static void Main(string[] args)
        {

            //read

            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            // calculation
            double hight = Math.Abs(y1 - y2);
            double lenght = Math.Abs(x1 - x2);

            double squad = hight * lenght;

            double perimetar = 2 * (hight + lenght);

            //print

            Console.WriteLine($"{squad:f2}");
            Console.WriteLine($"{perimetar:f2}");

        }
    }
}
