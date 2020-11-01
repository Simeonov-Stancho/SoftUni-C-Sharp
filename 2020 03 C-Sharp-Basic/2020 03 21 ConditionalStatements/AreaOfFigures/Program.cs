using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                double area = a * a;
                Console.WriteLine($"{area:f3}");
            }

            else if (figure == "rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                double area = sideA * sideB;
                Console.WriteLine($"{area:f3}");
            }

            else if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double area = Math.PI * r * r;
                Console.WriteLine($"{area:f3}");

            }

            else if (figure == "triangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                double area = (sideA * sideB) / 2;
                Console.WriteLine($"{area:f3}");

            }
        }
    }
}

