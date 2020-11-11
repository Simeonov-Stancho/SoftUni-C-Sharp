using System;

namespace _01OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookName = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());
            int counter = 0;

            string currentBook = Console.ReadLine();

            while (bookName != currentBook)
            {
                counter ++;
                if (capacity <= counter)
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;
                }
                currentBook = Console.ReadLine();
            }
            if (bookName == currentBook)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
        }
    }
}
