using System;

namespace _04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            string reverseCommand = "";

            for (int i = command.Length-1; i >=0; i--)
            {
                reverseCommand += command[i];
            }

            Console.WriteLine(reverseCommand);
        }
    }
}
