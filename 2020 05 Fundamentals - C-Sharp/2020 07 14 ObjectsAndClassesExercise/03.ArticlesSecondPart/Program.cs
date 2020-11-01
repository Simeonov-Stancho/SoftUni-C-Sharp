using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ArticlesSecondPart
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Articles> articles = new List<Articles>();

            for (int i = 0; i < n; i++)
            {
                string[] inputCommand = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                Articles article = new Articles(inputCommand[0], inputCommand[1], inputCommand[2]);
                articles.Add(article);
            }

            string command = Console.ReadLine();

            if (command == "title")
            {
                Console.WriteLine(String.Join(Environment.NewLine, articles.OrderBy(x => x.Title)));
            }

            else if (command == "content")
            {
                Console.WriteLine(String.Join(Environment.NewLine, articles.OrderBy(x => x.Content)));
            }

            else if (command == "author")
            {
                Console.WriteLine(String.Join(Environment.NewLine, articles.OrderBy(x => x.Author)));
            }
        }

        public class Articles
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public Articles(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }
}
