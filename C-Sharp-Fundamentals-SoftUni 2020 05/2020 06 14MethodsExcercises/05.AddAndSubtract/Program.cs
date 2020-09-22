using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            Console.WriteLine(Subtract(Sum(number1, number2), number3));
        }

        static int Sum(int num1, int num2)
        {
            int resultSum = num1 + num2;
            return resultSum;
        }

        static int Subtract(int numSum, int num3)
        {
            int resultSubtract = numSum - num3;
            return resultSubtract;
        }
    }
}
