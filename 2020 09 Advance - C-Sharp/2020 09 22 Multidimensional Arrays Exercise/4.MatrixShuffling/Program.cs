using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = ReadMatrix(array);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                bool isValid = CheckValidInput(matrix, command);

                if (isValid)
                {
                    matrix = SwapMatrix(matrix, command);
                    PrintMAtrix(matrix);
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

            }
        }

        static string[,] ReadMatrix(int[] array)
        {
            string[,] matrix = new string[array[0], array[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }

        static bool CheckValidInput(string[,] matrix, string[] command)
        {
            bool isValid = true;
            if (command[0] != "swap"
                || command.Length != 5) // isNumber
            {
                isValid = false;
            }

            else
            {
                string currentCommand = command[0];
                int row1 = int.Parse(command[1]);
                int col1 = int.Parse(command[2]);
                int row2 = int.Parse(command[3]);
                int col2 = int.Parse(command[4]);

                int rowLength = matrix.GetLength(0);
                int colLength = matrix.GetLength(1);

                if ((currentCommand != "swap") ||
                (0 > row1 || row1 >= rowLength) ||
                (0 > row2 || row2 >= rowLength) ||
                (0 > col1 || col1 >= colLength) ||
                (0 > col2 || col2 >= colLength))
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        static string[,] SwapMatrix(string[,] matrix, string[] command)
        {
            int row1 = int.Parse(command[1]);
            int col1 = int.Parse(command[2]);
            int row2 = int.Parse(command[3]);
            int col2 = int.Parse(command[4]);

            string current = matrix[row1, col1];
            string swap = matrix[row2, col2];

            matrix[row1, col1] = swap;
            matrix[row2, col2] = current;

            return matrix;
        }

        static void PrintMAtrix(string[,] matrix)
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
    }
}
