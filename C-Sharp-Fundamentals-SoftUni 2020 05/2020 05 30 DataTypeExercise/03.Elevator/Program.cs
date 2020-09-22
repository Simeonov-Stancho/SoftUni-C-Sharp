using System;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            double courses = n * 1.0 / capacity;
            Console.WriteLine(Math.Ceiling(courses));


        }
    }
}
