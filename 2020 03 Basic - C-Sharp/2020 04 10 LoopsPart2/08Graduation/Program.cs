using System;

namespace _08Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int count = 0;
            double averageGrade = 0;

            while (count < 12)
            {
                double grades = double.Parse(Console.ReadLine());

                if (grades < 4.00)
                {
                    continue;
                }
                averageGrade += grades;
                count++;
            }
            Console.WriteLine($"{name} graduated. Average grade: {averageGrade/12:f2}");
        }
    }
}
