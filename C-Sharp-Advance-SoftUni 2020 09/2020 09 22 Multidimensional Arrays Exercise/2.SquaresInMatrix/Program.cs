using System;
using System.Linq;

namespace _2.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = ReadMatrix(array);

            int equalNum = CheckForEqualSquares(matrix);

            Console.WriteLine(equalNum);
        }

        static char[,] ReadMatrix(int[] array)
        {
            int rows = array[0];
            int columns = array[1];

            char[,] matrix = new char[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] charArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = charArray[col];
                }
            }

            return matrix;
        }

        static int CheckForEqualSquares(char[,] matrix)
        {
            int equalNum = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if ((matrix[row, col] == matrix[row, col + 1]) &&
                        (matrix[row + 1, col] == matrix[row + 1, col + 1]) &&
                        (matrix[row, col] == matrix[row + 1, col]))
                    {
                        equalNum++;
                        continue;
                    }
                }
            }
            return equalNum;
        }
    }
}