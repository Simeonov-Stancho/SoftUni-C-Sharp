using System;
using System.Text;

namespace _05.DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

             StringBuilder stringOfDigits = new StringBuilder();
            StringBuilder stringOfLetters = new StringBuilder();
            StringBuilder stringOfOtherCharracter = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                if (currentChar >= 48 && currentChar <= 57)
                {
                    stringOfDigits.Append(currentChar);
                }

                else if ((currentChar >= 65 && currentChar <= 90) ||
                    (currentChar >= 97 && currentChar <= 122))
                {
                    stringOfLetters.Append(currentChar);
                }

                else
                {
                    stringOfOtherCharracter.Append(currentChar);
                }
            }

            string digits = stringOfDigits.ToString();
            string letters = stringOfLetters.ToString();
            string otherChar = stringOfOtherCharracter.ToString();

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(otherChar);
        }
    }
}
