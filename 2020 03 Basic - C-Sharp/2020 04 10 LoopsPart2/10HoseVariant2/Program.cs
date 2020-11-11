using System;

namespace _10HoseVariant2
{
    class Program
    {
        static void Main(string[] args)
        {
            int widht = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeSpace = widht * lenght * height;

            string boxCount = Console.ReadLine();
            int box = 0;

            while (boxCount != "Done")
            {
                box = int.Parse(boxCount);
                freeSpace -= box;

                if (freeSpace > 0)
                {
                    boxCount = Console.ReadLine();
                    continue;
                }

                else
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
                    break;
                }
            }
            if (freeSpace > 0)
            {
                Console.WriteLine($"{Math.Abs(freeSpace)} Cubic meters left.");
            }

        }
    }
}
