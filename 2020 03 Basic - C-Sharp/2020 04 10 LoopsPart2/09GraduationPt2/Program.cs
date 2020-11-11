using System;

namespace _09GraduationPt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine(); //ok

            double count = 0; //ok
            double gradeTotal = 0;
            double averageGrade = 0; //ok
            int repeat = 0;

            while (count < 12)
            {
                double grades = double.Parse(Console.ReadLine());

                if (grades >= 4.00)
                {
                    count++;
                    gradeTotal += grades;
                    averageGrade = gradeTotal / count;
                    continue;
                }

                else if (grades < 4.00) //ok
                {
                    repeat++;
                    if (repeat < 2)
                    {
                        continue;
                    }
                    else
                    {
                        count++;
                        break;
                    }
                }

            }

            if (repeat > 1)
            {
                Console.WriteLine($"{name} has been excluded at {count} grade");

            }
            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
            }
        }
    }
}
