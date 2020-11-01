using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            List<Students> students = new List<Students>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Students student = new Students(input[0], input[1], double.Parse(input[2]));
                students.Add(student);
            }

            Console.WriteLine(string.Join(Environment.NewLine, students.OrderByDescending(x => x.Grade)));
        }

        public class Students
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }

            public Students(string firstName, string lastName, double grade)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Grade = grade;
            }

            public override string ToString()
            {
                return $"{FirstName} {LastName}: {Grade:f2}";
            }
        }
    }
}
