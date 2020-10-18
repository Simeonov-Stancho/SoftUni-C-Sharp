using System;
using System.Linq;
using System.Text;

namespace _02._2019October26BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string lettetrs = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);
            int[] possition = FindPlayer(matrix);
            MarkPossition(matrix, possition);
            string command;
            StringBuilder sb = new StringBuilder();
            sb.Append(lettetrs);

            while ((command = Console.ReadLine()) != "end")
            {
                MakeAMove(command, possition);

                if (possition[0] < 0 || possition[0] >= n
                    || possition[1] < 0 || possition[1] >= n)
                {
                    if (sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }

                    CheckPossition(n, possition);
                    continue;
                }

                if (char.IsLetter(matrix[possition[0], possition[1]]))
                {
                    sb.Append(matrix[possition[0], possition[1]]);
                    MarkPossition(matrix, possition);
                }
            }

            matrix[possition[0], possition[1]] = 'P';
            Console.WriteLine(sb);
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

        static int[] FindPlayer(char[,] matrix)
        {
            int[] possition = new int[2];
            char currentChar = 'P';
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

        static void MarkPossition(char[,] matrix, int[] possition)
        {
            matrix[possition[0], possition[1]] = '-';
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
                possition[0] = 0;
            }

            else if (possition[0] >= n)
            {
                possition[0] = n - 1;
            }

            else if (possition[1] < 0)
            {
                possition[1] = 0;
            }

            else if (possition[1] >= n)
            {
                possition[1] = n - 1;
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