using System;

namespace _7.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] matrix = new long[rows][];

            matrix = ReadMatrix(matrix);

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < row + 1; col++)
                {

                    if (col > 0 && col < matrix[row].Length - 1)
                    {
                        matrix[row][col] = matrix[row - 1][col - 1] + matrix[row - 1][col];
                    }

                    else
                    {
                        matrix[row][col] = 1;
                    }
                }
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        static long[][] ReadMatrix(long[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new long[row + 1];
                for (int col = 0; col < row + 1; col++)
                {
                    matrix[row][col] = 1;
                }
            }

            return matrix;
        }
    }
}
