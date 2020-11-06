using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SportCar bmw = new SportCar(555, 50.5);
            bmw.Drive(10);
            Console.WriteLine(bmw.Fuel);
        }
    }
}
