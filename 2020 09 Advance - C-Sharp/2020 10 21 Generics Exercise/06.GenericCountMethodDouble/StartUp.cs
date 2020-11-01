using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> data = new List<double>();

            for (int i = 0; i < n; i++)
            {
                data.Add(double.Parse(Console.ReadLine()));
            }

            double value = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>(data);
            Console.WriteLine(box.ReturnCount(value));
        }
    }
}