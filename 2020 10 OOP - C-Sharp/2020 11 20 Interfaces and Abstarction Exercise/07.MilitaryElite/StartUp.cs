using _07.MilitaryElite.Core;
using _07.MilitaryElite.Core.Contracts;
using _07.MilitaryElite.IO;
using _07.MilitaryElite.IO.Contracts;
using System;

namespace _07.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
