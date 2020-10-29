using System;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstPlayerTime = int.Parse(Console.ReadLine());
            int secondPlayerTime = int.Parse(Console.ReadLine());
            int thirdPlayerTime = int.Parse(Console.ReadLine());

            int totalTime = firstPlayerTime + secondPlayerTime + thirdPlayerTime;

            int minutes = totalTime / 60;
            int seconds = totalTime % 60;

            Console.WriteLine($"{minutes}:{seconds:d2}");

        }
    }
}
