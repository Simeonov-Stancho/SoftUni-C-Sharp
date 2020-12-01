using System;

using _03.Raiding.IO.Contracts;

namespace _03.Raiding.IO.Models
{
    public class ConsoleReader : IReader
    {
        public string ReadLIne()
        {
            return Console.ReadLine();
        }
    }
}