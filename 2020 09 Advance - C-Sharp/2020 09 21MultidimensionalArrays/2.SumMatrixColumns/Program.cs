using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = array[0];
            int column = array[1];

            int[,] matrix = new int[rows, column];

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

            List<int> colSum = SumMatrixColumn(matrix);
            for (int i = 0; i < colSum.Count; i++)
            {
                Console.WriteLine(colSum[i]);
            }
            
        }

        static List<int> SumMatrixColumn(int[,] matrix)
        {

            List<int> colSum = new List<int>();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }

                colSum.Add(sum);
            }

            return colSum;
        }
    }
}
