using System;
using System.Linq;

namespace _5.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string snake = Console.ReadLine();

            char[,] matrix = ReadMatrix(array, snake);
            PrintMatrix(matrix);
        }

        static char[,] ReadMatrix(int[] array, string snake)
        {
            int rows = array[0];
            int column = array[1];
            char[,] matrix = new char[rows, column];

            int count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (count < snake.Length)
                        {
                            matrix[row, col] = snake[count];
                            count++;
                        }

                        else
                        {
                            count = 0;
                            matrix[row, col] = snake[count];
                            count++;
                            continue;
                        }
                    }
                }

                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (count < snake.Length)
                        {
                            matrix[row, col] = snake[count];
                            count++;
                        }

                        else
                        {
                            count = 0;
                            matrix[row, col] = snake[count];
                            count++;
                            continue;
                        }
                    }
                }
            }

            return matrix;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
