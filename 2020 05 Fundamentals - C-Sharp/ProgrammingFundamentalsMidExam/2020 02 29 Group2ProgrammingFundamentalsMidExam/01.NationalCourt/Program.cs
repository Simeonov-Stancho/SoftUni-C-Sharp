using System;

namespace _01.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int employee1Efficiency = int.Parse(Console.ReadLine());
            int employee2Efficiency = int.Parse(Console.ReadLine());
            int employee3Efficiency = int.Parse(Console.ReadLine());

            int people = int.Parse(Console.ReadLine());

            int courtEfficiencyPerHour = employee1Efficiency + employee2Efficiency + employee3Efficiency;
            int time = 0;
            int workingTime = 0;

            while (people > 0)
            {
                workingTime++;

                if (workingTime % 4 == 0)
                {
                    time++;
                    workingTime = 0;
                    continue;
                }

                else
                {
                    people -= courtEfficiencyPerHour;
                    time++;
                }
            }

            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
