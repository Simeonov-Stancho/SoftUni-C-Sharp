using System;

namespace _02BeehiveRole
{
    class Program
    {
        static void Main(string[] args)
        {
            double intellect = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            string role = "";

            if (intellect >= 80 && power >= 80 && gender == "female")
            {
                role = "Queen Bee";
            }


            else if (intellect >= 80)
            {
                role = "Repairing Bee";
            }

            else if (intellect >= 60)
            {
                role = "Cleaning Bee";
            }

            else
            {
                if (power >= 80 && gender == "male")
                {
                    role = "Drone Bee";
                }

                else if (power >= 60)
                {
                    role = "Guard Bee";
                }

                else
                {
                    role = "Worker Bee";
                }
            }

            Console.WriteLine(role);
        }
    }
}
