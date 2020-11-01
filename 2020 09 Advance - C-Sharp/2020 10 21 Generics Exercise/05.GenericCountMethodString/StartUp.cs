using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> data = new List<string>();

            for (int i = 0; i < n; i++)
            {
                data.Add(Console.ReadLine());
            }

           string value = Console.ReadLine();

            Box<string> box = new Box<string>(data);
            Console.WriteLine(box.ReturnCount(value));
        }
    }
}
