using System;
using System.Numerics;

namespace _01.IntegerOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine()); 
            int thirdNumber = int.Parse(Console.ReadLine()); 
            int fourtNumber = int.Parse(Console.ReadLine());

            long calculationAdd = (long)firstNumber + (long)secondNumber;
            long calculationDivide = calculationAdd / thirdNumber;
            long calculationMultiply = calculationDivide * fourtNumber;

            Console.WriteLine(calculationMultiply);
        }
    }
}
