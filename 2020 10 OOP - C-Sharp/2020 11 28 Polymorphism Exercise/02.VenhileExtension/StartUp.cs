using _01.VehiclesKristiyanIvanov.Core;
using _01.VehiclesKristiyanIvanov.IO.Contracts;
using _01.VehiclesKristiyanIvanov.IO.Models;

namespace _01.VehiclesKristiyanIvanov
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