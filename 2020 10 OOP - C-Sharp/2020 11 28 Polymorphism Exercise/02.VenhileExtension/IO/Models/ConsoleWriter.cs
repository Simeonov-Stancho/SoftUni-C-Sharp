using _01.VehiclesKristiyanIvanov.IO.Contracts;
using System;


namespace _01.VehiclesKristiyanIvanov.IO.Models
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text); ;
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text); ;
        }
    }
}
