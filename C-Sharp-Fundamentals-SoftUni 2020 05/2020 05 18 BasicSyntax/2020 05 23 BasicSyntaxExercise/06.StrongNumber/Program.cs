using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string strNum = "";
            strNum += number;
            int factoralSum = 0;
            int num = number;

            for (int i = 0; i < strNum.Length; i++)
            {
                int currentDigit = num % 10;
                num = (num - currentDigit) / 10;

                int factorial = 1;

                for (int x = 1; x <= currentDigit; x++)
                {
                    factorial *= x;
                }
                factoralSum += factorial;
            }

            if (factoralSum == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
