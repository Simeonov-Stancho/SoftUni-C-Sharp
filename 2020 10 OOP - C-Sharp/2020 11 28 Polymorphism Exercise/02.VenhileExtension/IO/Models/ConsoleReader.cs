using System;

using _01.VehiclesKristiyanIvanov.IO.Contracts;

namespace _01.VehiclesKristiyanIvanov.IO.Models
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine(); ;
        }
    }
}
