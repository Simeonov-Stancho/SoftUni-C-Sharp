using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            //read recordTime=sec; distance=m; timePerMeter = sec

            double recordTime = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

            //calculate time>recordTime
            

            if (distance<15)
            {
                double time = distance * timePerMeter;
                if (time < recordTime)
                {
                    double dif = recordTime - time;
                    Console.WriteLine($"Yes, he succeeded! The new world record is { time:f2} seconds.");
                }
                else
                {
                    double dif = time - recordTime;
                    Console.WriteLine($"No, he failed! He was { dif:f2} seconds slower.");
                }
            }

            else
            {
                double extraTime = Math.Floor(distance / 15) * 12.5;
                double time = (distance * timePerMeter) + extraTime;
                if (time < recordTime)
                {
                    double dif = recordTime - time;
                    Console.WriteLine($"Yes, he succeeded! The new world record is { time:f2} seconds.");
                }
                else
                {
                    double dif = time - recordTime;
                    Console.WriteLine($"No, he failed! He was {dif:f2} seconds slower.");
                }
            }
        }
    }
}
