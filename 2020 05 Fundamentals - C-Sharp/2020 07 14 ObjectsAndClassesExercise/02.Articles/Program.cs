using System;
using System.Linq;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputCommand = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Article article = new Article(inputCommand[0], inputCommand[1], inputCommand[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                string newText = string.Empty;

                if (command[0] == "Edit")
                {
                    article.Edit(command[1]);
                }

                else if (command[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(command[1]);
                }

                else if (command[0] == "Rename")
                {
                    article.Rename(command[1]);
                }
            }

            Console.WriteLine(article.ToString());
        }

        public class Article
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public void Edit(string content)
            {
                this.Content = content;
            }

            public void ChangeAuthor(string author)
            {
                this.Author = author;
            }

            public void Rename(string title)
            {
                this.Title = title;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }
}
