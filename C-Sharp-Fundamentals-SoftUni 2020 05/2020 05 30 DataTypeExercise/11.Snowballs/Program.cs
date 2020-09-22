using System;
using System.Numerics;

namespace _11.Snowballs100form100
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int snowballSnowMax = 0;
            int snowballTimeMax = 0;
            int snowballQualityMax = 0;
            BigInteger snowballValueMax = 0;
            BigInteger snowballValue = 0;

            for (int i = 0; i < n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (snowballValue > snowballValueMax)
                {
                    snowballSnowMax = snowballSnow;
                    snowballTimeMax = snowballTime;
                    snowballQualityMax = snowballQuality;
                    snowballValueMax = snowballValue;
                }
            }

            Console.WriteLine($"{snowballSnowMax} : {snowballTimeMax} = {snowballValueMax} ({snowballQualityMax})");
        }
    }
}