using System;
using System.Linq;

namespace _6.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = ReadJaggedMatrix(rows);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Add")
                {
                    matrix = AddValue(matrix, command);
                }

                else if (command[0] == "Subtract")
                {
                    matrix = SubtractValue(matrix, command);
                }
            }

            PrintJaggedMatrix(matrix);
            Console.WriteLine();
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

        static int[][] AddValue(int[][] matrix, string[] command)
        {
            int row = int.Parse(command[1]);
            int col = int.Parse(command[2]);
            int value = int.Parse(command[3]);

            if ((matrix.Length <= row || row < 0)
                || matrix[row].Length <= col || col < 0)
            {
                Console.WriteLine("Invalid coordinates");
            }

            else
            {
                matrix[row][col] += value;
            }

            return matrix;
        }

        static int[][] SubtractValue(int[][] matrix, string[] command)
        {
            int row = int.Parse(command[1]);
            int col = int.Parse(command[2]);
            int value = int.Parse(command[3]);

            if ((matrix.Length <= row || row < 0)
                || matrix[row].Length <= col || col < 0)
            {
                Console.WriteLine("Invalid coordinates");
            }

            else
            {
                matrix[row][col] -= value;
            }

            return matrix;
        }

        static void PrintJaggedMatrix(int[][] matrix)
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
