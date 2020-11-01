using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int dnaLenght = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            int bestLenght = 0;
            int[] bestDnaNumber = new int[dnaLenght];
            int startingIndex = dnaLenght;
            int bestSum = 0;
            int count = 0;
            int bestIndex = 0;

            while (command != "Clone them!")
            {
                int[] dna = command.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); ;
                int lenght = 0;
                int maxLenght = 0;
                int index = 0;
                int dnaSum = 0;
                count++;

                for (int i = 0; i < dna.Length; i++)
                {
                    dnaSum += dna[i];
                    if (dna[i] == 1)
                    {
                        lenght++;
                    }

                    else
                    {
                        lenght = 0;
                    }

                    if (maxLenght < lenght)
                    {
                        maxLenght = lenght;
                        index = i - maxLenght + 1;
                    }
                }

                if (maxLenght > bestLenght)
                {
                    bestLenght = maxLenght;
                    bestDnaNumber = dna;
                    startingIndex = index;
                    bestSum = dnaSum;
                    bestIndex = count;
                }

                else if (maxLenght == bestLenght)
                {
                    if (startingIndex > index)
                    {
                        bestLenght = maxLenght;
                        bestDnaNumber = dna;
                        startingIndex = index;
                        bestSum = dnaSum;
                        bestIndex = count;
                    }

                    else if (startingIndex == index)
                    {
                        if (dnaSum > bestSum)
                        {
                            bestLenght = maxLenght;
                            bestDnaNumber = dna;
                            startingIndex = index;
                            bestSum = dnaSum;
                            bestIndex = count;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestIndex} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestDnaNumber));
        }
    }
}