using System;

namespace _06Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());

            int cakePcs = width * lenght;
            string command = Console.ReadLine();

            while (command != "STOP")
            {
                int takenPart = int.Parse(command);

                if (cakePcs > takenPart)
                {
                    cakePcs -= takenPart;
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    cakePcs -= takenPart;
                    Console.WriteLine($"No more cake left! You need {Math.Abs(cakePcs)} pieces more.");
                    return;
                }
            }
            if (command == "STOP" && cakePcs > 0)
            {

                Console.WriteLine($"{cakePcs} pieces are left.");
            }
        }
    }
}
