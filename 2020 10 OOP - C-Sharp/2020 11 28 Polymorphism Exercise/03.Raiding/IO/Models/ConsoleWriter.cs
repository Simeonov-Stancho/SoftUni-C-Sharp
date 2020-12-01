using System;

using _03.Raiding.IO.Contracts;

namespace _03.Raiding.IO.Models
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
