using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = ReadList();
            List<int> secondList = ReadList();

            List<int> resultList = ResultList(firstList, secondList);

            Console.WriteLine(string.Join(" ", resultList));
        }

        static List<int> ReadList()
        {
            List<int> list = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            return list;
        }

        static List<int> ResultList(List<int> firstList, List<int> secondList)
        {
            List<int> resultList = new List<int>();

            if (firstList.Count <= secondList.Count)
            {
                for (int i = 0; i < firstList.Count; i++)
                {
                    resultList.Add(firstList[i]);
                    resultList.Add(secondList[i]);
                }

                for (int i = firstList.Count; i < secondList.Count; i++)
                {
                    resultList.Add(secondList[i]);
                }
            }

            else
            {
                for (int i = 0; i < secondList.Count; i++)
                {
                    resultList.Add(firstList[i]);
                    resultList.Add(secondList[i]);
                }

                for (int i = secondList.Count; i < firstList.Count; i++)
                {
                    resultList.Add(firstList[i]);
                }
            }

            return resultList;
        }
    }
}
