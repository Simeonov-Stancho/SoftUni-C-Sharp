using System;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNum = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            int rest = 0;

            if (secondNum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (firstNum[0] == 48)
            {
                firstNum = firstNum.Remove(0, 1);
            }

            for (int i = firstNum.Length - 1; i >= 0; i--)
            {
                int currentChar = (firstNum[i] - 48) * secondNum + rest;

                if (currentChar > 9)
                {
                    string text = currentChar.ToString();
                    rest = text[0] - 48;
                    sb.Insert(0, text[1]);
                }

                else
                {
                    sb.Insert(0, currentChar);
                    rest = 0;
                }
            }

            if (rest > 0)
            {
                sb.Insert(0, rest);
            }

            Console.WriteLine(sb);
        }
    }
}
