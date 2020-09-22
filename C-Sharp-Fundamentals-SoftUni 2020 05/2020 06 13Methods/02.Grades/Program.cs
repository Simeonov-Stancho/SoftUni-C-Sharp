using System;

namespace _02.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintGrade(double.Parse(Console.ReadLine()));
        }

        static void PrintGrade(double first)
        {
            if (first >= 2 && first <= 2.99)
            {
                Console.WriteLine("Fail");
            }

            else if (first >= 3 && first <= 3.49)
            {
                Console.WriteLine("Poor");
            }

            else if (first >= 3.5 && first <= 4.49)
            {
                Console.WriteLine("Good");
            }

            else if (first >= 4.5 && first <= 5.49)
            {
                Console.WriteLine("Very good");
            }

            else if (first >= 5.5 && first <= 6)
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}
