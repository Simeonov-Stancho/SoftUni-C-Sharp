using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);
            char symbol = Console.ReadLine()[0]; //Char.TryParse(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currentChar = matrix[row, col];

                    if (symbol == currentChar)
                    {
                        Console.WriteLine("(" + row + ", " + col + ")");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");

        }

        static char[,] ReadMatrix(int n)
        {
            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] array = Console.ReadLine().ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            return matrix;
        }
    }
}
