using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = array[0];
            int[,] matrix = ReaDMatrix(n);
            Queue<int> queue = new Queue<int>();

            string input;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] rowAndCol = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int currentRow = rowAndCol[0];
                int currentCol = rowAndCol[1];

                if (CheckIsOut(n, currentRow, currentCol))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                else
                {
                    matrix[currentRow, currentCol] = 1;
                    queue.Enqueue(currentRow);
                    queue.Enqueue(currentCol);
                }
            }

            while (queue.Count != 0)
            {
                int row = queue.Dequeue();
                int col = queue.Dequeue();

                MarkPossition(matrix, row, col);
            }

            PrintMatrix(matrix);
        }

        static int[,] ReaDMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

            return matrix;
        }

        static bool CheckIsOut(int n, int row, int col)
        {
            bool isOut = false;

            if ((row < 0 || row >= n) ||
                (col < 0 || col >= n))
            {
                isOut = true;
            }

            return isOut;
        }

        static void MarkPossition(int[,] matrix, int row, int col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == row)
                {
                    continue;
                }

                matrix[i, col]++;
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (i == col)
                {
                    continue;
                }

                matrix[row, i]++;
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}