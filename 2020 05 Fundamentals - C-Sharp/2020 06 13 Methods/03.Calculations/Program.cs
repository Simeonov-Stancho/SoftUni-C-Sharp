using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            switch (command)
            {
                case "add":
                    Add(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                    break;

                case "subtract":
                    Subtract(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                    break;

                case "multiply":
                    Multiply(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                    break;

                case "divide":
                    Divide(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                    break;
            }
        }

        static void Add(double second, double third)
        {

            Console.WriteLine(second + third);
        }

        static void Subtract(double second, double third)
        {
            Console.WriteLine(second - third);
        }

        static void Multiply(double second, double third)
        {
            Console.WriteLine(second * third);
        }

        static void Divide(double second, double third)
        {
            Console.WriteLine(second / third);
        }
    }
}
