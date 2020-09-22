using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string reversedString = string.Empty;
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversedString += input[i];
                }

                Console.WriteLine(input + " = " + reversedString);
                input = string.Empty;
            }
        }
    }
}
