using System;

namespace Time15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            //read hours and minutes from 24:00
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());


            // Calulate hours after 15 min
            // hours 0-23; minutes 0-59

            if (minute <= 44)
            {
                int minutes = minute + 15;
                Console.WriteLine($"{hour}:{minutes:d2}");
            }
            else
            {
                if (hour < 23)
                {
                    int minutes = minute + 15 - 60;
                    int hours = hour + 1;
                    Console.WriteLine($"{hours}:{minutes:d2}");
                }
                else if (hour == 23)
                {
                    int minutes = minute + 15 - 60;
                    int hours = 0;
                    Console.WriteLine($"{hours}:{minutes:d2}");
                }
            }


        }
    }
}
