using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            //read
            int countTabBrowser = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            int penalty = 0;
            int totalPenalty = 0;
            //for read
            for (int i = 1; i <= countTabBrowser; i++)
            {
                string tabBrowser = Console.ReadLine();

                //penalty Facebook = 150; Instagram = 100; Reddit = 50;
                switch (tabBrowser)
                {
                    case "Facebook":
                        penalty = 150;
                        break;

                    case "Instagram":
                        penalty = 100;
                        break;

                    case "Reddit":
                        penalty = 50;
                        break;
                    default:
                        penalty = 0;
                        break;
                }
                totalPenalty += penalty;

                if (salary <= totalPenalty)
                {
                    Console.WriteLine("You have lost your salary.");
                    countTabBrowser = i;
                }

            }
            if (salary > totalPenalty)
            {
                Console.WriteLine(salary - totalPenalty);
            }
        }
    }
}
