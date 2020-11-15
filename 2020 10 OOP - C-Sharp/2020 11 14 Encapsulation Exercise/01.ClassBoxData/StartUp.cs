using System;

namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box currentBox = new Box(length, width, height);
                Console.WriteLine($"Surface Area - {currentBox.CalculateSurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {currentBox.CalculateLeteralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {currentBox.CalculateVolume():f2}");
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}