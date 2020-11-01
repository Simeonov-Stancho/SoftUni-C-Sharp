using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentString = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < currentString.Length; i++)
            {
                sb.Append((char)(currentString[i] + 3));
            }

            Console.WriteLine(sb);
        }
    }
}