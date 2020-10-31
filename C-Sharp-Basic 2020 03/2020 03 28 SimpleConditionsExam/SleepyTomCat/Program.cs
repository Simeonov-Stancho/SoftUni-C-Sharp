using System;

namespace SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            // read
            int holliday = int.Parse(Console.ReadLine());
            int playTimeNorm = 30000;

            //warkingDay day gameTime1 = 63 min/day

            int warkingDay = 365 - holliday;
            int gameTime1 = warkingDay * 63;

            //holliday day gameTime2 = 127 min/day
            
            int gameTime2 = holliday * 127;

            //calculate difference = playTimeNorm - 30 000

            int difference = playTimeNorm - gameTime1 - gameTime2;

            //if sleep well, playTimeNorm <= 30 000min/365 days
            int hours = difference / 60;
            int minutes = difference % 60;


            if (difference < 0)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{-hours} hours and {-minutes} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }
           
        }
    }
}
