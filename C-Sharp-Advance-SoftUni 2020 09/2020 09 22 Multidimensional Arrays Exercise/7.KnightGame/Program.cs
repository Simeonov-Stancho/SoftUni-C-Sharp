using System;
using System.Linq;

namespace _7.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(rows);

            int knightRow = 0;
            int knightCol = 0;
            int count = 0;
            string end = string.Empty;

            while (end != "END")
            {
                int strongestAttack = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int currentAttack = 0;

                        if (matrix[row, col] == 'K')
                        {
                            if ((IsValidIndex(row - 2, col - 1, matrix))
                                && (IsKnight(row - 2, col - 1, matrix)))
                            {
                                currentAttack++;
                            }

                            if ((IsValidIndex(row - 2, col + 1, matrix))
                                && (IsKnight(row - 2, col + 1, matrix)))
                            {
                                currentAttack++;
                            }

                            if ((IsValidIndex(row + 2, col - 1, matrix))
                                && (IsKnight(row + 2, col - 1, matrix)))
                            {
                                currentAttack++;
                            }

                            if ((IsValidIndex(row + 2, col + 1, matrix))
                                && (IsKnight(row + 2, col + 1, matrix)))
                            {
                                currentAttack++;
                            }

                            if ((IsValidIndex(row - 1, col - 2, matrix))
                                && (IsKnight(row - 1, col - 2, matrix)))
                            {
                                currentAttack++;
                            }

                            if ((IsValidIndex(row - 1, col + 2, matrix))
                                 && (IsKnight(row - 1, col + 2, matrix)))
                            {
                                currentAttack++;
                            }

                            if ((IsValidIndex(row + 1, col - 2, matrix))
                                && (IsKnight(row + 1, col - 2, matrix)))
                            {
                                currentAttack++;
                            }

                            if ((IsValidIndex(row + 1, col + 2, matrix))
                                && (IsKnight(row + 1, col + 2, matrix)))
                            {
                                currentAttack++;
                            }
                        }

                        if (currentAttack > strongestAttack)
                        {
                            strongestAttack = currentAttack;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (strongestAttack != 0)
                {
                    matrix[knightRow, knightCol] = 'O';
                    count++;
                }

                else
                {
                    end = "END";
                }
            }

            Console.WriteLine(count);
        }

        static char[,] ReadMatrix(int rows)
        {
            char[,] matrix = new char[rows, rows];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string column = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = column[col];
                }
            }

            return matrix;
        }

        static bool IsValidIndex(int row, int col, char[,] matrix)
        {
            bool isValid = false;
            if ((0 <= row && row < matrix.GetLength(0))
                && (0 <= col && col < matrix.GetLength(1)))
            {
                isValid = true;
            }

            return isValid;
        }

        static bool IsKnight(int row, int col, char[,] matrix)
        {
            bool isKnight = false;
            if (matrix[row, col] == 'K')
            {
                isKnight = true;
            }

            return isKnight;
        }
    }
}
