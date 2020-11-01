using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> student = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!student.ContainsKey(name))
                {
                    student.Add(name, new List<double>());
                    student[name].Add(grade);
                }

                else
                {
                    student[name].Add(grade);
                }
            }

            student = student.OrderByDescending(x => x.Value.Average()).ToDictionary(x => x.Key, x => x.Value);

            foreach (var pair in student)
            {
                if (pair.Value.Average() < 4.5)
                {
                    student.Remove(pair.Key);
                }

                else
                {
                    Console.WriteLine($"{pair.Key} -> {pair.Value.Average():f2}");
                }
            }
        }
    }
}
