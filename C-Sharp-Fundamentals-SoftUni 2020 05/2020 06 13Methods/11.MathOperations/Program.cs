using System;
using System.Reflection;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNun = int.Parse(Console.ReadLine());
            char operatorType = char.Parse(Console.ReadLine());
            int secondNun = int.Parse(Console.ReadLine());

            switch (operatorType)
            {
                case '+':
                    Console.WriteLine(Add(firstNun, secondNun)); ;
                    break;

                case '-':
                    Console.WriteLine(Subtract(firstNun, secondNun)); ;
                    break;

                case '*':
                    Console.WriteLine(Multiply(firstNun, secondNun)); ;
                    break;

                case '/':
                    Console.WriteLine(Divide(firstNun, secondNun)); ;
                    break;
            }
        }

        static int Add(int second, int third)
        {
            int result = second + third;
            return result;
        }

        static int Subtract(int second, int third)
        {
            int result = second - third;
            return result;
        }

        static int Multiply(int second, int third)
        {
            int result = second * third;
            return result;
        }

        static int Divide(int second, int third)

        {
            int result = second / third;
            return result;
        }
    }
}
