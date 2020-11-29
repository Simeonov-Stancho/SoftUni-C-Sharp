using _01.Vehicles.IO.Contracts;

namespace _01.Vehicles.IO.Models
{
    public class ConsoleWriter : IWriter

    {
        public void Write(string text)
        {
            System.Console.Write(text);
        }

        public void WriteLine(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}
