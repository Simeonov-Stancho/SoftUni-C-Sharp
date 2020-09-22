using System;
using System.Linq;

namespace _04.PrintAndsum
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string input = Console.ReadLine();

            string password = "";
            int count = 0;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            while (password != input)
            {
                count++;

                if (count == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }

                Console.WriteLine("Incorrect password. Try again.");
                input = Console.ReadLine();
            }

            if (password == input)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
