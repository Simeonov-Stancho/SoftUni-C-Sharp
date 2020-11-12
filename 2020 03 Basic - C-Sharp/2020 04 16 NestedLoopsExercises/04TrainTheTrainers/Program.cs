using System;

namespace _04TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judge = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            double presentationSum = 0;
            double averageGradeSum = 0;
            double averageTotalGrade = 0;
            double counter = 0;

            while (presentationName != "Finish")
            {
                double gradeSum = 0;

                for (int rating = 1; rating <= judge; rating++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    gradeSum += grade;
                }

                averageGradeSum = gradeSum / judge;
                Console.WriteLine($"{presentationName} - {averageGradeSum:f2}.");

                counter++;
                presentationSum += averageGradeSum;
                averageTotalGrade = presentationSum / counter;

                presentationName = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {averageTotalGrade:f2}.");
        }
    }
}
