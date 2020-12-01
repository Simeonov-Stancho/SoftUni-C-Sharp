using System;

using _04.WildFarm.IO.Contracts;

namespace _04.WildFarm.IO.Models
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
