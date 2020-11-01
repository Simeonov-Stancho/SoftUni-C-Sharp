using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            //read
            double income = double.Parse(Console.ReadLine());
            double success = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());


            //Calculate Social scholarship = income * 0.35; income<MinSalary and success>4.50
            //Calculate  scholarship = success* 25; if success>=5.5

            if (income > minSalary)
            {
                if (success >= 5.5)
                {
                    double scholarship = success * 25;
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarship)} BGN");
                }
                else
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }                            
            }

            else if (income <= minSalary)
            {
                if (success <= 4.50)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
                else if (success >= 5.5)
                {
                    double socialScholarship = minSalary * 0.35;
                    double scholarship = success * 25;

                    if (socialScholarship > scholarship)
                    {
                        Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                    }
                    else if (socialScholarship <= scholarship)
                    {
                        Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarship)} BGN");
                    }
                }
                else
                {
                    double socialScholarship = minSalary * 0.35;
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                }
            }

        }
    }
}
