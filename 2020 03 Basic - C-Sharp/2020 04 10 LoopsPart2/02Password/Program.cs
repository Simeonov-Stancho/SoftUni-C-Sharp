using System;

namespace _02Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = Console.ReadLine();
            string passwordTry = Console.ReadLine();

            while (password != passwordTry)
            {
                passwordTry = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {userName}!");
        }
    }
}
