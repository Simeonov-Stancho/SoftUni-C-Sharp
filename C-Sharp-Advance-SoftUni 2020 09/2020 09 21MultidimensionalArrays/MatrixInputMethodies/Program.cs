using System;
using System.Linq;

namespace MatrixInputMethodies
{
    class Program
    {
        char symbol = Console.ReadLine()[0];

        static void Main(string[] args)
        {
            static int[,] ReadMatrixChar(int n)
            {
                int[,] matrix = new int[n, n];

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

            static int[,] ReadMatrixInt(int[] array)
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

            static int[][] ReadJaggedMatrix(int rows)
            {
                int[][] matrix = new int[rows][];

                for (int row = 0; row < matrix.Length; row++)
                {
                    int[] rowData = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    matrix[row] = new int[rowData.Length];

                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = rowData[col];
                    }
                }

                return matrix;
            }

        }
    }
}
