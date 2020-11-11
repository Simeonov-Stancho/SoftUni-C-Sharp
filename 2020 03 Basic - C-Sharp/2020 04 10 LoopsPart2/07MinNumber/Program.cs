using System;

namespace _07MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int minValue = int.MaxValue;
            int count = 0;

            while (n > count)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                count++;

                if (currentNumber < minValue)
                {
                    minValue = currentNumber;
                }
            }
            Console.WriteLine(minValue);
        }
    }
}
