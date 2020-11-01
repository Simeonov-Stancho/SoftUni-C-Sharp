using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = FillMatrix(array);

            int sum = int.MinValue;
            int[,] squareMatrix = new int[2, 2];

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = (matrix[row, col] + matrix[row, col + 1]) +
                                    (matrix[row + 1, col] + matrix[row + 1, col + 1]);
                    if (sum < currentSum)
                    {
                        sum = currentSum;

                        squareMatrix[0, 0] = matrix[row, col]; ;
                        squareMatrix[0, 1] = matrix[row, col + 1];
                        squareMatrix[1, 0] = matrix[row + 1, col];
                        squareMatrix[1, 1] = matrix[row + 1, col + 1];
                    }
                }
            }

            PrintMatrix(squareMatrix);
            Console.WriteLine(SumMatrix(squareMatrix));
        }

        static int[,] FillMatrix(int[] array)
        {
            int rows = array[0];
            int columns = array[1];

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        static int SumMatrix(int[,] matrix)
        {
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }
            }

            return sum;
        }
    }
}
