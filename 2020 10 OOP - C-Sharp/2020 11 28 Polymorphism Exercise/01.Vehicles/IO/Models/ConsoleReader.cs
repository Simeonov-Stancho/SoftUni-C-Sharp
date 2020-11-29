using _01.Vehicles.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.IO.Models
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine(); ;
        }
    }
}
