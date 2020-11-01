using System;
using System.Threading.Tasks;

namespace _01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int efficiency1 = int.Parse(Console.ReadLine());
            int efficiency2 = int.Parse(Console.ReadLine());
            int efficiency3 = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());

            int efficiency = efficiency1 + efficiency2 + efficiency3;
            int time = 0;
            int tasks = students;

            while (tasks > 0)
            {
                if (time % 4 == 0)
                {
                    time++;
                    continue;
                }

                tasks -= efficiency;
                time++;
            }

            if (students == 0)
            {
                Console.WriteLine($"Time needed: {time}h.");
            }

            else
            {
                Console.WriteLine($"Time needed: {time - 1}h.");
            }
        }
    }
}
