using System;

namespace _01.ExperienceGainingGroup2
{
    class Program
    {
        static void Main(string[] args)
        {
            double experienceNeeded = double.Parse(Console.ReadLine());
            int battlesCount = int.Parse(Console.ReadLine());

            double currentExperiance = 0;
            int count = 0;
            bool isSuccess = false;

            for (int i = 1; i <= battlesCount; i++)
            {
                double experiencePerBattle = double.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    experiencePerBattle *= 1.15;
                }

                if (i % 5 == 0)
                {
                    experiencePerBattle *= 0.9;
                }

                currentExperiance += experiencePerBattle;
                count++;

                if (currentExperiance >= experienceNeeded)
                {
                    isSuccess = true;
                    break;
                }
            }

            if (isSuccess)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {count} battles.");
            }

            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {(experienceNeeded - currentExperiance):f2} more needed.");
            }
        }
    }
}
