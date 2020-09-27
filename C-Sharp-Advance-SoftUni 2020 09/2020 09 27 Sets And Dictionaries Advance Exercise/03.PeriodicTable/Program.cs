using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> uniqueChemicalCompounds = new SortedSet<string>();
            
            for (int i = 0; i < n; i++)
            {
                string[] chemicalCompounds = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < chemicalCompounds.Length; j++)
                {
                    uniqueChemicalCompounds.Add(chemicalCompounds[j]);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueChemicalCompounds));
        }
    }
}