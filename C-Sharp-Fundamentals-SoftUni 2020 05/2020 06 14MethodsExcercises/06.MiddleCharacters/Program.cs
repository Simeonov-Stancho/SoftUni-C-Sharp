using System;
using System.Text;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            if (text.Length % 2 == 0)
            {
                Console.WriteLine(FindMiddleCharInEvenText(text));
            }
            else
            {
                Console.WriteLine(FindMiddleCharInOddText(text));
            }
        }

        static string FindMiddleCharInEvenText(string text)
        {
            StringBuilder middlesChar = new StringBuilder();
            for (int i = (text.Length / 2); i <= ((text.Length / 2) + 1); i++)
            {
                middlesChar.Append(text[i - 1]);
            }

            return middlesChar.ToString();
        }

        static char FindMiddleCharInOddText(string text)
        {
            char middleChar = (char)(text[(text.Length / 2)]);
            return middleChar;
        }
    }
}
