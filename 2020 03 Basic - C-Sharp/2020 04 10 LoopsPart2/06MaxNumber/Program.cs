using System;

namespace _06MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int count = 0;
            int number = int.MinValue;
            int currentNumber = 0;

            while (n > count)
            {
                currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber > number)
                {
                    number = currentNumber;
                }
                count++;
            }
            Console.WriteLine(number);
        }
    }
}
