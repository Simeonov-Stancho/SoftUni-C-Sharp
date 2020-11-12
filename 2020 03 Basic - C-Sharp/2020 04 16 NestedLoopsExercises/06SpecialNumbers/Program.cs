using System;

namespace _06SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= 9; firstDigit++)
            {
                for (int secondDigit = 1; secondDigit <= 9; secondDigit++)
                {
                    for (int thirdDigit = 1; thirdDigit <= 9; thirdDigit++)
                    {
                        for (int fourtDigit = 1; fourtDigit <= 9; fourtDigit++)
                        {
                            if (number % firstDigit == 0 && number % secondDigit == 0 && number % thirdDigit == 0 && number % fourtDigit == 0)
                            {
                                Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{fourtDigit} ");
                            }
                        }
                    }
                }
            }
        }
    }
}