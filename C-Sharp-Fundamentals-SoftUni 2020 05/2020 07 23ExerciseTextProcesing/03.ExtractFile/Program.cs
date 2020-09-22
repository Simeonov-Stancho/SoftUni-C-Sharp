using System;
using System.Linq;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split(new char[] { '.', '\\' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Console.WriteLine($"File name: {array[array.Length - 2]}");
            Console.WriteLine($"File extension: {array[array.Length - 1]}");
        }
    }
}