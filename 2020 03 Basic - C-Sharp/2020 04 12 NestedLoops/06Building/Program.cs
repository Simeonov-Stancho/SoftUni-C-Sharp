using System;

namespace _06Building
{
    class Program
    {
        static void Main(string[] args)
        {
            // i-- room num
            // floorNum % 2 ==0 --> offices
            // floorNum % 2!= 0 --> apartments
            //apName --> A{floorNum}{apNum}, apNum start with 0;
            //officeNum --> O{floorNum}{officeNum}, officeNum start with 0;
            //lastFloor -->apartments -> L not A. If only 1 floor -> ap is L.

            int floor = int.Parse(Console.ReadLine());
            int room = int.Parse(Console.ReadLine());

            for (int i = floor; i >= 1; i--)
            {
                if (i == floor )
                {
                    for (int x = 0; x < room; x++)
                    {
                        if (x < room-1)
                        {
                            Console.Write($"L{i}{x} ");
                        }
                        else
                        {
                            Console.WriteLine($"L{i}{x}");
                        }
                        
                    }
                }
                if (i % 2 == 0 && i!= floor)
                {
                    for (int x = 0; x < room; x++)
                    {
                        if (x < room - 1)
                        {
                            Console.Write($"O{i}{x} ");
                        }
                        else
                        {
                            Console.WriteLine($"O{i}{x}");
                        }
                        
                    }
                }
                else if (i % 2 != 0 && i != floor)
                {
                    for (int x = 0; x < room; x++)
                    {
                        if (x < room - 1)
                        {
                            Console.Write($"A{i}{x} ");
                        }
                        else
                        {
                            Console.WriteLine($"A{i}{x}");
                        }
                        
                    }
                }
            }
        }
    }
}
