using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] matrix = ReadMatrix(rows);
            matrix = AnalyzingMatrix(matrix);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input
                             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                             .ToArray();

                matrix = ManipulateMatrix(matrix, command);
            }

            PrintMatrix(matrix);
        }

        static double[][] ReadMatrix(int rows)
        {
            double[][] matrix = new double[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                matrix[row] = new double[array.Length];

                for (int col = 0; col < array.Length; col++)
                {
                    matrix[row][col] = array[col];
                }
            }

            return matrix;
        }

        static double[][] AnalyzingMatrix(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = matrix[row][col] * 2;
                        matrix[row + 1][col] = matrix[row + 1][col] * 2;
                    }
                }

                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = matrix[row][col] / 2;
                    }

                    for (int i = 0; i < matrix[row + 1].Length; i++)
                    {
                        matrix[row + 1][i] = matrix[row + 1][i] / 2;
                    }
                }
            }

            return matrix;
        }

        static double[][] ManipulateMatrix(double[][] matrix, string[] command)
        {
            string currentCommand = command[0];
            int row = int.Parse(command[1]);
            int column = int.Parse(command[2]);
            int value = int.Parse(command[3]);

            if ((row >= 0 && row < matrix.Length) &&
                (column >= 0 && column < matrix[row].Length))
            {
                if (currentCommand == "Add")
                {
                    matrix[row][column] = matrix[row][column] + value;
                }

                else if (currentCommand == "Subtract")
                {
                    matrix[row][column] = matrix[row][column] - value;
                }
            }

            return matrix;
        }

        static void PrintMatrix(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
