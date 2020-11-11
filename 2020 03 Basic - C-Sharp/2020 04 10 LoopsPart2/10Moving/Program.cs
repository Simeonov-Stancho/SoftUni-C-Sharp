using System;

namespace _10Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            // cacluclate free space of the new apartment, after laguage
            //1 box = width 1m* lenght 1m*1m

            int widthtFreeSpace = int.Parse(Console.ReadLine());
            int lenghtFreeSpace = int.Parse(Console.ReadLine());
            int hightFreeSpace = int.Parse(Console.ReadLine());

            int volumeFreeSPace = widthtFreeSpace * lenghtFreeSpace * hightFreeSpace;
            int volumeBox = 0;
            int freeSpace = 0;
            string comand = "";
            
            

            while (volumeFreeSPace > volumeBox)
            {
                comand = Console.ReadLine();
                
                if (comand != "Done")
                {
                    volumeBox += int.Parse(comand);
                    freeSpace = volumeFreeSPace - volumeBox;
                    continue;
                }

                else
                {
                    break;
                }
            }

            if (freeSpace <= 0)
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
            }
            else if (comand == "Done")
            {
                Console.WriteLine($"{Math.Abs(freeSpace)} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(freeSpace)} Cubic meters left.");
            }


            //while comand "Done" read and count box
            //when read comand Done  or when no free space -->break
        }
    }
}
