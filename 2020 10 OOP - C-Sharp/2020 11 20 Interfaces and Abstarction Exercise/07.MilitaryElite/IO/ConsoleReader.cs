using System;

using _07.MilitaryElite.IO.Contracts;

namespace _07.MilitaryElite.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
