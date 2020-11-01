using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[,] matrix = ReadMatrix(rows);
            int primaryDiagonal = CalculateDiagonalSum(matrix);
            int secondaryDiagonal = CalculateSecondaryDiagonalSum(matrix);

            int sum = Math.Abs(primaryDiagonal - secondaryDiagonal);
            Console.WriteLine(sum);
        }

        static int[,] ReadMatrix(int rows)
        {
            int[,] matrix = new int[rows, rows];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }

        static int CalculateDiagonalSum(int[,] matrix)
        {
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, row];
            }

            return sum;
        }

        static int CalculateSecondaryDiagonalSum(int[,] matrix)
        {
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int rows = row;
                int column = matrix.GetLength(0) - 1 - row;

                sum += matrix[rows, column];
            }

            return sum;
        }
    }
}
