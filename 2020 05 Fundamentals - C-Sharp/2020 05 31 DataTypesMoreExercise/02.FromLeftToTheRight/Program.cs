using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            long qty = long.Parse(Console.ReadLine());

            for (int i = 0; i < qty; i++)
            {
                var line = Console.ReadLine();
                var numbers = line.Split(' ');
                long rightNumber = 0;
                long leftNumber = 0;
                long sum = 0;

                long[] numberssss = Array.ConvertAll(numbers, long.Parse);

                leftNumber = numberssss[0];
                rightNumber = numberssss[1];

                if (rightNumber >= leftNumber)
                {
                    rightNumber = Math.Abs(rightNumber);
                    string rightString = rightNumber.ToString();
                    for (int k = 0; k < rightString.Length; k++)
                    {
                        sum += rightString[k] - 48;
                    }
                }

                else
                {
                    leftNumber = Math.Abs(leftNumber);
                    string leftString = leftNumber.ToString();
                    for (int h = 0; h < leftString.Length; h++)
                    {
                        sum += leftString[h] - 48;
                    }
                }
                Console.WriteLine(sum);
            }
        }
    }
}
