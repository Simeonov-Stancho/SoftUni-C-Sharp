using System;

namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            //read
            int prоjectTime = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int warkers = int.Parse(Console.ReadLine());


            //10%holliday
            double warkingDays = days * 0.9;

            //oneDay = 8 hours + overTime = 2 hours
            double warkingHours = warkingDays * 10 * warkers;
            //Math.Floor(hours)

            double difference = prоjectTime - warkingHours;

            if (prоjectTime <= warkingHours)
            {
                Console.WriteLine($"Yes!{Math.Floor(-difference)} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{Math.Floor(difference)} hours needed.");
            }
        }
    }
}
