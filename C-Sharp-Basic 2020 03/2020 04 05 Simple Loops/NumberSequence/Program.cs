using System;

namespace NumberSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;
            for (int i = 0; i < number; i++)
            {
                int currNumber = int.Parse(Console.ReadLine());

                if (maxNumber < currNumber)
                {
                    maxNumber = currNumber;
                }

                if (minNumber > currNumber)
                {
                    minNumber = currNumber;
                }
            }

            Console.WriteLine($"Max number: { maxNumber}");
            Console.WriteLine($"Min number: { minNumber}");
        }
    }
}
