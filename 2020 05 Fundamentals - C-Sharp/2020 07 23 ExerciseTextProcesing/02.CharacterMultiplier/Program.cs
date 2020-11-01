using System;
using System.Linq;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string first = array[0];
            string second = array[1];
            Console.WriteLine(SumOfCharacters(first, second));
        }

        static int SumOfCharacters(string first, string second)
        {
            int characterSum = 0;
            if (first.Length == second.Length)
            {
                for (int i = 0; i < first.Length; i++)
                {
                    for (int j = i; j <= i; j++)
                    {
                        int multiply = first[i] * second[i];
                        characterSum += multiply;
                    }
                }
            }

            else if (first.Length > second.Length)
            {
                for (int i = 0; i < second.Length; i++)
                {
                    for (int j = i; j <= i; j++)
                    {
                        int multiply = first[i] * second[i];
                        characterSum += multiply;
                    }
                }

                for (int i = second.Length; i < first.Length; i++)
                {
                    characterSum += first[i];
                }
            }

            else
            {
                for (int i = 0; i < first.Length; i++)
                {
                    for (int j = i; j <= i; j++)
                    {
                        int multiply = first[i] * second[i];
                        characterSum += multiply;
                    }
                }

                for (int i = first.Length; i < second.Length; i++)
                {
                    characterSum += second[i];
                }
            }

            return characterSum;
        }
    }
}
