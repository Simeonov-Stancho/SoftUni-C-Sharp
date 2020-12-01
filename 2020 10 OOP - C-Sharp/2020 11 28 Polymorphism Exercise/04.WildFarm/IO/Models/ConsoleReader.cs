using System;

using _04.WildFarm.IO.Contracts;

namespace _04.WildFarm.IO.Models
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine(); ;
        }
    }
}
