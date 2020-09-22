using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            while (secondString.Contains(firstString))
            {
                int index = secondString.IndexOf(firstString);
                int lenght = firstString.Length;
                secondString = secondString.Remove(index, lenght);
            }

            Console.WriteLine(secondString);
        }
    }
}
