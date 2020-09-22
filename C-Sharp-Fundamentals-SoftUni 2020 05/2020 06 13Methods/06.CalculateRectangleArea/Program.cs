using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RectangelArea(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
        }

        static int RectangelArea(int a, int b)
        {
            return a * b;
        }
    }
}
