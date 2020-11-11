using System;

namespace _04Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10k foot/day -->"Goal reached! Good job!"  
            // when is tierd go home with comand "Going home" and foot to home, if not "{разликата между стъпките} more steps to reach goal."
            // 

            string command = Console.ReadLine();

            int totalFoot = 0;

            while (command != "Going home")
            {
                int foot = int.Parse(command);
                totalFoot += foot;

                if (totalFoot >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    return;
                }
                else
                {
                    command = Console.ReadLine();
                    continue;
                }
            }
            if (command == "Going home")
            {
                int footHome = int.Parse(Console.ReadLine());
                totalFoot += footHome;
                if (totalFoot < 10000)
                {
                    Console.WriteLine($"{Math.Abs(10000 - totalFoot)} more steps to reach goal.");
                }
                else
                {
                    Console.WriteLine("Goal reached! Good job!");
                }
            }

        }
    }
}
