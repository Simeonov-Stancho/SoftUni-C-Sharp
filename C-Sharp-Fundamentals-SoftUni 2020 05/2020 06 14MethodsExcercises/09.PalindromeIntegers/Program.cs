using System;
using System.Text;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == CheckIsItPalindrome(command))
                {
                    Console.WriteLine("true");
                }

                else
                {
                    Console.WriteLine("false");
                }
                command = Console.ReadLine();
            }
        }

        static string CheckIsItPalindrome(string number)
        {
            StringBuilder newNumber = new StringBuilder();
            for (int i = number.Length; i > 0; i--)
            {
                newNumber.Append(number[i - 1]);
            }

            return newNumber.ToString();
        }
    }
}
