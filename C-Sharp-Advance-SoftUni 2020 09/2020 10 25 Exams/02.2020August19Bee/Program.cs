using System;
using System.Linq;

namespace _02._2020August19Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReaDMatrix(n);

            int[] beePossition = FindBee(matrix);
            int beeRow = beePossition[0];
            int beeCol = beePossition[1];
            matrix[beeRow, beeCol] = '.';

            int pollinatedFlowersCount = 0;
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                beePossition = MakeAMove(command, beeRow, beeCol);
                beeRow = beePossition[0];
                beeCol = beePossition[1];

                if (CheckIsOut(n, beeRow, beeCol))
                {
                    PrintGotOut();
                    break;
                }

                char currentChar = matrix[beeRow, beeCol];

                if (currentChar == 'f')
                {
                    pollinatedFlowersCount++;
                    matrix[beeRow, beeCol] = '.';
                }

                if (currentChar == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    beePossition = MakeAMove(command, beeRow, beeCol);
                    beeRow = beePossition[0];
                    beeCol = beePossition[1];

                    if (CheckIsOut(n, beeRow, beeCol))
                    {
                        PrintGotOut();
                        break;
                    }

                    currentChar = matrix[beeRow, beeCol];

                    if (currentChar == 'f')
                    {
                        pollinatedFlowersCount++;
                        matrix[beeRow, beeCol] = '.';
                    }
                }
            }

            if (pollinatedFlowersCount < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowersCount} flowers more");
            }

            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowersCount} flowers!");
            }

            if (!CheckIsOut(n, beeRow, beeCol))
            {
                matrix[beeRow, beeCol] = 'B';
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

        static int[] FindBee(char[,] matrix)
        {
            int[] beePossition = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        beePossition[0] = row;
                        beePossition[1] = col;
                        break;
                    }
                }
            }

            return beePossition;
        }

        static int[] MakeAMove(string command, int beeRow, int beeCol)
        {
            int[] currentPossition = new int[2];

            if (command == "up")
            {
                beeRow -= 1;
            }

            else if (command == "down")
            {
                beeRow += 1;
            }

            else if (command == "left")
            {
                beeCol -= 1;
            }

            else if (command == "right")
            {
                beeCol += 1;
            }

            currentPossition[0] = beeRow;
            currentPossition[1] = beeCol;

            return currentPossition;
        }

        static bool CheckIsOut(int n, int beeRow, int beeCol)
        {
            bool isOut = false;

            if ((beeRow < 0 || beeRow == n) ||
                (beeCol < 0 || beeCol == n))
            {
                isOut = true;
            }

            return isOut;
        }

        static void PrintGotOut()
        {
            Console.WriteLine("The bee got lost!");
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