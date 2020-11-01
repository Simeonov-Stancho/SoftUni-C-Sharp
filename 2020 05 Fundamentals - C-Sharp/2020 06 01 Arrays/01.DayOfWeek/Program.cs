using System;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayNum = int.Parse(Console.ReadLine());

            string[] days = new string[7];
            days[0] = "Monday";
            days[1] = "Tuesday";
            days[2] = "Wednesday";
            days[3] = "Thursday";
            days[4] = "Friday";
            days[5] = "Saturday";
            days[6] = "Sunday";

            if (dayNum <= 7 && dayNum > 0)
            {
                Console.WriteLine(days[dayNum - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
