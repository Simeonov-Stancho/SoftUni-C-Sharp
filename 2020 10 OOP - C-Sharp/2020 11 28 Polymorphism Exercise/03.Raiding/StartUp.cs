using System;

using _03.Raiding.Core;
using _03.Raiding.IO.Contracts;
using _03.Raiding.IO.Models;

namespace _03.Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
