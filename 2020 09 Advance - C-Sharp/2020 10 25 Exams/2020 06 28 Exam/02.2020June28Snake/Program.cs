using System;
using System.Linq;

namespace _02._2020June28Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReaDMatrix(n);

            int[] snakePossition = FindSnake(matrix);
            int snakeRow = snakePossition[0];
            int snakeCol = snakePossition[1];
            matrix[snakeRow, snakeCol] = '.';

            int foodCount = 0;
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                snakePossition = MakeAMove(command, snakeRow, snakeCol);
                snakeRow = snakePossition[0];
                snakeCol = snakePossition[1];

                if (CheckIsOut(n, snakeRow, snakeCol))
                {
                    PrintGotOut();
                    break;
                }

                char currentChar = matrix[snakeRow, snakeCol];

                if (currentChar == '*')
                {
                    foodCount++;
                }

                if (currentChar == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    snakePossition = FindBurrow(matrix);
                    snakeRow = snakePossition[0];
                    snakeCol = snakePossition[1];
                }

                if (foodCount >= 10)
                {
                    break;
                }

                matrix[snakeRow, snakeCol] = '.';
            }

            if (foodCount >= 10)
            {
                Console.WriteLine($"You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodCount}");

            if (!CheckIsOut(n, snakeRow, snakeCol))
            {
                matrix[snakeRow, snakeCol] = 'S';
            }

            PrintMatrix(matrix);
        }

        static char[,] ReaDMatrix(int n)
        {
            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }

        static int[] FindSnake(char[,] matrix)
        {
            int[] snakePossition = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        snakePossition[0] = row;
                        snakePossition[1] = col;
                        break;
                    }
                }
            }

            return snakePossition;
        }

        static int[] FindBurrow(char[,] matrix)
        {
            int[] snakePossition = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        snakePossition[0] = row;
                        snakePossition[1] = col;
                        break;
                    }
                }
            }

            return snakePossition;
        }

        static int[] MakeAMove(string command, int snakeRow, int snakeCol)
        {
            int[] currentPossition = new int[2];

            if (command == "up")
            {
                snakeRow -= 1;
            }

            else if (command == "down")
            {
                snakeRow += 1;
            }

            else if (command == "left")
            {
                snakeCol -= 1;
            }

            else if (command == "right")
            {
                snakeCol += 1;
            }

            currentPossition[0] = snakeRow;
            currentPossition[1] = snakeCol;

            return currentPossition;
        }

        static bool CheckIsOut(int n, int snakeRow, int snakeCol)
        {
            bool isOut = false;

            if ((snakeRow < 0 || snakeRow == n) ||
                (snakeCol < 0 || snakeCol == n))
            {
                isOut = true;
            }

            return isOut;
        }

        static void PrintGotOut()
        {
            Console.WriteLine("Game over!");
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
