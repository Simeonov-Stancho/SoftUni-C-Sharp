using System;

namespace _02.EnglishNameOfTheLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string currentNum = number.ToString();

            int lastDigitNum = currentNum.Length - 1;
            char lastDigit = currentNum[lastDigitNum];
            string print = "";

            switch (lastDigit)
            {
                case '1':
                    print = "one";
                    break;

                case '2':
                    print = "two";
                    break;

                case '3':
                    print = "three";
                    break;

                case '4':
                    print = "four";
                    break;

                case '5':
                    print = "five";
                    break;

                case '6':
                    print = "six";
                    break;

                case '7':
                    print = "seven";
                    break;

                case '8':
                    print = "eight";
                    break;

                case '9':
                    print = "nine";
                    break;

                case '0':
                    print = "zero";
                    break;
            }
            Console.WriteLine(print);
        }
    }
}
