using System;

namespace _04SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int counter = 0;
            bool found = false;

            for (int i = num1; i <= num2; i++)
            {
                for (int a = num1; a <= num2; a++)
                {
                    counter++;
                    if (i + a == magicNum)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {a} = {magicNum})");
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }

            }
            if (found == false)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
            }
        }
    }
}
