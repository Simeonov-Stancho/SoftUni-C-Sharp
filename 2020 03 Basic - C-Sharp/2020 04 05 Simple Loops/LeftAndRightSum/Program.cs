using System;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumber = int.Parse(Console.ReadLine());
            int sumRight = 0;
            int sumLeft = 0;
            for (int i = 0; i < countNumber; i++)
            {
                int leftCount = int.Parse(Console.ReadLine());
                sumLeft += leftCount;
            }

            for (int i = 0; i < countNumber; i++)
            {
                int rightCount = int.Parse(Console.ReadLine());
                sumRight += rightCount;
            }

            if (sumLeft == sumRight)
            {
                Console.WriteLine($"Yes, sum = {sumLeft}");
            }
            else
            {
                int diff = 0;
                if (sumLeft > sumRight)
                {
                    diff = sumLeft - sumRight;
                }

                else
                {
                    diff = sumRight - sumLeft;
                }
                Console.WriteLine($"No, diff = {diff}");
             }
        }
    }
}
