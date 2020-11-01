using System;

namespace _04BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if (minutes >= 30)
            {
                hours += 1;
                minutes -= 30;

                if (hours >= 23)
                {
                    hours = 0;
                }

                Console.WriteLine($"{hours}:{minutes:d2}");
            }
            else
            {
                Console.WriteLine($"{hours}:{(minutes + 30):d2}");
            }
        }
    }
}
