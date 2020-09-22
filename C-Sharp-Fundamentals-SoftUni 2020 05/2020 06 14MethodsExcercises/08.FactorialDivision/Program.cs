using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = int.Parse(Console.ReadLine());
            double number2 = int.Parse(Console.ReadLine());
            double factorielFirstNum = CalculateFacturiel(number1);
            double factorielSecondNum = CalculateFacturiel(number2);

            Console.WriteLine($"{(factorielFirstNum / factorielSecondNum):f2}");


        }

        static double CalculateFacturiel(double number)
        {
            double factoriel = 1;
            for (int i = 1; i <= number; i++)
            {
                factoriel *= i;
            }

            return factoriel;
        }
    }
}
