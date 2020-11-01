using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SchoolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine()
                            .Split('&', StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Done")
            {
                List<string> command = input
                            .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                if (command[0] == "Add Book")
                {
                    if (!books.Contains(command[1]))
                    {
                        books.Insert(0, command[1]);
                    }
                }

                else if (command[0] == "Take Book")
                {
                    if (books.Contains(command[1]))
                    {
                        books.Remove(command[1]);
                    }
                }

                else if (command[0] == "Swap Books")
                {
                    string firstBook = command[1];
                    string secondBook = command[2];

                    if (books.Contains(firstBook) && books.Contains(secondBook))
                    {
                        int indexFirstBook = books.IndexOf(firstBook);
                        int indexSecondBook = books.IndexOf(secondBook);

                        books[indexFirstBook] = secondBook;
                        books[indexSecondBook] = firstBook;
                    }
                }

                else if (command[0] == "Insert Book")
                {
                    books.Add(command[1]);
                }

                else if (command[0] == "Check Book")
                {
                    int index = int.Parse(command[1]);

                    if (index >= 0 && index <= books.Count)
                    {
                        string book = books[index];
                        Console.WriteLine(book);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", books));
        }
    }
}
