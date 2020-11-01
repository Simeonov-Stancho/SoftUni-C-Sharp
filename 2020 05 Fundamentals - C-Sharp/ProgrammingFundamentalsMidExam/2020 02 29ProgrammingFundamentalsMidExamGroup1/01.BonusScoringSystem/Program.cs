using System;
using System.ComponentModel.DataAnnotations;

namespace _01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());

            double maxBonus = double.MinValue;
            double maxAttendances = double.MinValue;


            for (int i = 0; i < students; i++)
            {
                double attendances = int.Parse(Console.ReadLine());
                double totalBonus = (attendances / lectures) * (5 + (bonus));

                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    maxAttendances = attendances;
                }

                if (lectures == 0 || attendances == 0)
                {
                    maxBonus = 0;
                    maxAttendances = attendances;
                }
            }

            if (lectures == 0 || students == 0)
            {
                maxBonus = 0;
                maxAttendances = 0;
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");
        }
    }
}