using System;
using System.Linq;

namespace _02._2019February24TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);
            int[] possitionFirstPlayer = FindPlayer(matrix, 'f');
            int[] possitionSecondPlayer = FindPlayer(matrix, 's');
            int count = 1;

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (count % 2 != 0)
                {
                    DoIt(command[0], possitionFirstPlayer, n);

                    if (matrix[possitionFirstPlayer[0], possitionFirstPlayer[1]] == 's')
                    {
                        matrix[possitionFirstPlayer[0], possitionFirstPlayer[1]] = 'x';
                        break;
                    }

                    else
                    {
                        matrix[possitionFirstPlayer[0], possitionFirstPlayer[1]] = 'f';
                    }
                    count++;
                }

                if (count % 2 == 0)
                {
                    DoIt(command[1], possitionSecondPlayer, n);

                    if (matrix[possitionSecondPlayer[0], possitionSecondPlayer[1]] == 'f')
                    {
                        matrix[possitionSecondPlayer[0], possitionSecondPlayer[1]] = 'x';
                        break;
                    }

                    else
                    {
                        matrix[possitionSecondPlayer[0], possitionSecondPlayer[1]] = 's';
                    }
                    count++;
                }
            }

            PrintMatrix(matrix);
        }

        static char[,] ReadMatrix(int n)
        {
            char[,] matrix = new char[n, n];

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

        static int[] FindPlayer(char[,] matrix, char playerChar)
        {
            int[] possition = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (playerChar == matrix[row, col])
                    {
                        possition[0] = row;
                        possition[1] = col;
                        break;
                    }
                }
            }

            return possition;
        }

        static void DoIt(string command, int[] possition, int n)
        {
            MakeAMove(command, possition);
            CheckPossition(n, possition);
        }

        static void MakeAMove(string command, int[] possition)
        {
            int[] currentPossition = new int[2];

            if (command == "up")
            {
                possition[0] -= 1;
            }

            else if (command == "down")
            {
                possition[0] += 1;
            }

            else if (command == "left")
            {
                possition[1] -= 1;
            }

            else if (command == "right")
            {
                possition[1] += 1;
            }
        }

        static void CheckPossition(int n, int[] possition)
        {
            if (possition[0] < 0)
            {
                possition[0] = n - 1;
            }

            else if (possition[0] >= n)
            {
                possition[0] = 0;
            }

            else if (possition[1] < 0)
            {
                possition[1] = n - 1;
            }

            else if (possition[1] >= n)
            {
                possition[1] = 0;
            }
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
