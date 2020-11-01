using System;
using System.Linq;

namespace _02._2020Feb22Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commandCount = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);
            int[] possition = FindPlayer(matrix);
            MarkPossition(matrix, possition);
            bool isFinished = false;

            for (int i = 0; i < commandCount; i++)
            {
                string command = Console.ReadLine();
                DoIt(command, possition, n, matrix);

                if (matrix[possition[0], possition[1]] == 'F')
                {
                    isFinished = true;
                    break;
                }

                else if (matrix[possition[0], possition[1]] == 'B')
                {
                    DoIt(command, possition, n, matrix);
                }

                else if (matrix[possition[0], possition[1]] == 'T')
                {
                    command = BackWards(command);
                    DoIt(command, possition, n, matrix);
                }

                else
                {
                    MarkPossition(matrix, possition);
                }
            }

            if (isFinished)
            {
                Console.WriteLine("Player won!");
                matrix[possition[0], possition[1]] = 'f';
            }

            else
            {
                Console.WriteLine("Player lost!");
                matrix[possition[0], possition[1]] = 'f';
            }

            PrintMatrix(matrix);
        }

        static void DoIt(string command, int[] possition, int n, char[,] matrix)
        {
            MakeAMove(command, possition);
            CheckPossition(n, possition);
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

        static int[] FindPlayer(char[,] matrix)
        {
            int[] possition = new int[2];
            char currentChar = 'f';
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (currentChar == matrix[row, col])
                    {
                        possition[0] = row;
                        possition[1] = col;
                        break;
                    }
                }
            }

            return possition;
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

        static void MarkPossition(char[,] matrix, int[] possition)
        {
            matrix[possition[0], possition[1]] = '-';
        }

        static string BackWards(string command)
        {
            if (command == "up")
            {
                command = "down";
            }

            else if (command == "down")
            {
                command = "up";
            }

            else if (command == "right")
            {
                command = "left";
            }

            else if (command == "left")
            {
                command = "right";
            }

            return command;
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
