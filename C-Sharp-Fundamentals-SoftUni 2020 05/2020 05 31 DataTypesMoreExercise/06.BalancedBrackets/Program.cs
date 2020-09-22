using System;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int openingChar = 0;
            int closingChar = 0;


            for (int i = 0; i < n; i++)
            {
                string symbol = Console.ReadLine();

                if (symbol == "(")
                {
                    openingChar++;
                }

                else if (symbol == ")")
                {
                    closingChar++;

                    if (openingChar - closingChar != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }
            }

            if (openingChar == closingChar)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
