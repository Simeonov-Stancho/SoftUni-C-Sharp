using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<string>> course = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string courseName = command[0];
                string studentName = command[1];


                if (!course.ContainsKey(courseName))
                {
                    course.Add(courseName, new List<string>());
                    course[courseName].Add(studentName);
                }

                else
                {
                    course[courseName].Add(studentName);
                    course[courseName].Sort();
                }
            }
            course = course.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);
            //

            foreach (var pair in course)
            {
                Console.WriteLine(pair.Key + ": " + (pair.Value.Count));
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    Console.WriteLine($"-- {pair.Value[i]}");
                }
            }
        }
    }
}