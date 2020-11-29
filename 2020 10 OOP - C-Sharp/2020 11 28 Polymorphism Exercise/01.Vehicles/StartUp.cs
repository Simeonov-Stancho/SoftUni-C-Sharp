using _01.Vehicles.Core;
using _01.Vehicles.IO.Contracts;
using _01.Vehicles.IO.Models;

namespace _01.Vehicles
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