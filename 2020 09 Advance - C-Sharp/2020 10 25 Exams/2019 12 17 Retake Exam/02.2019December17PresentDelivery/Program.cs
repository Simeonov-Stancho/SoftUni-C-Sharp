using System;
using System.Linq;

namespace _02._2019December17PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);
            int[] possition = FindSanta(matrix);
            MarkPossition(matrix, possition);
            int niceKidCount = NiceKidCount(matrix);
            int presentDelivery = 0;

            string command;
            while ((command = Console.ReadLine()) != "Christmas morning")
            {
                MakeAMove(command, possition);

                if (matrix[possition[0], possition[1]] == 'X')
                {
                    MarkPossition(matrix, possition);
                    continue;
                }

                else if (matrix[possition[0], possition[1]] == 'V')
                {
                    presentsCount--;
                    niceKidCount--;
                    presentDelivery++;
                    MarkPossition(matrix, possition);
                }

                else if (matrix[possition[0], possition[1]] == 'C')
                {
                    if ((presentsCount > 0) &&
                        (matrix[possition[0] - 1, possition[1]] == 'V'
                        || matrix[possition[0] - 1, possition[1]] == 'X'))
                    {
                        if (matrix[possition[0] - 1, possition[1]] == 'X')
                        {
                            niceKidCount++;
                        }

                        presentsCount--;
                        niceKidCount--;
                        presentDelivery++;
                        matrix[possition[0] - 1, possition[1]] = '-';
                    }

                    if ((presentsCount > 0) &&
                        (matrix[possition[0] + 1, possition[1]] == 'V'
                        || matrix[possition[0] + 1, possition[1]] == 'X'))
                    {
                        if (matrix[possition[0] + 1, possition[1]] == 'X')
                        {
                            niceKidCount++;
                        }
                        presentsCount--;
                        niceKidCount--;
                        presentDelivery++;
                        matrix[possition[0] + 1, possition[1]] = '-';
                    }

                    if ((presentsCount > 0) &&
                        (matrix[possition[0], possition[1] - 1] == 'V'
                        || matrix[possition[0], possition[1] - 1] == 'X'))
                    {
                        if (matrix[possition[0], possition[1] - 1] == 'X')
                        {
                            niceKidCount++;
                        }
                        presentsCount--;
                        niceKidCount--;
                        presentDelivery++;
                        matrix[possition[0], possition[1] - 1] = '-';
                    }

                    if ((presentsCount > 0) &&
                        (matrix[possition[0], possition[1] + 1] == 'V'
                        || matrix[possition[0], possition[1] + 1] == 'X'))
                    {
                        if (matrix[possition[0], possition[1] + 1] == 'X')
                        {
                            niceKidCount++;
                        }
                        presentsCount--;
                        niceKidCount--;
                        presentDelivery++;
                        matrix[possition[0], possition[1] + 1] = '-';
                    }
                }

                else
                {
                    MarkPossition(matrix, possition);
                }

                if (presentsCount == 0)
                {
                    break;
                }
            }

            if (presentsCount == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            matrix[possition[0], possition[1]] = 'S';
            PrintMatrix(matrix);

            if (niceKidCount == 0)
            {
                Console.WriteLine($"Good job, Santa! {presentDelivery} happy nice kid/s.");
            }

            else
            {
                Console.WriteLine($"No presents for {niceKidCount} nice kid/s.");
            }
        }

        static char[,] ReadMatrix(int n)
        {
            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] array = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            return matrix;
        }

        static int[] FindSanta(char[,] matrix)
        {
            int[] possition = new int[2];
            char currentChar = 'S';
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

        static int NiceKidCount(char[,] matrix)
        {
            int count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        static void PrintMatrix(char[,] matrix)
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
