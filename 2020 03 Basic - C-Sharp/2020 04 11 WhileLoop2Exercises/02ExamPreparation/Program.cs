using System;

namespace _02ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int possibleLowGrade = int.Parse(Console.ReadLine());

            int counter = 0;
            double gradeSum = 0;
            int lowGrade = 0;
            string lastTask = "";

            string taskName = Console.ReadLine();

            while (taskName != "Enough")
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade > 4)
                {
                    counter++;
                    gradeSum += grade;
                    lastTask = taskName;
                    taskName = Console.ReadLine();
                }
                else
                {
                    lowGrade++;
                    counter++;
                    gradeSum += grade;

                    if (lowGrade >= possibleLowGrade)
                    {
                        Console.WriteLine($"You need a break, {lowGrade} poor grades.");
                        return;
                    }

                    else
                    {
                        taskName = Console.ReadLine();
                        continue;
                    }
                }
            }
            if (taskName == "Enough")
            {
                Console.WriteLine($"Average score: {gradeSum / counter:f2}");
                Console.WriteLine($"Number of problems: {counter}");
                Console.WriteLine($"Last problem: {lastTask}");
            }
        }
    }
}
