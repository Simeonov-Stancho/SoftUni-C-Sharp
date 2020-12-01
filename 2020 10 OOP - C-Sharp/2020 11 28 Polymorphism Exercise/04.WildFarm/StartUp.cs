using _04.WildFarm.Core;
using _04.WildFarm.IO.Contracts;
using _04.WildFarm.IO.Models;
using System;

namespace _04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
