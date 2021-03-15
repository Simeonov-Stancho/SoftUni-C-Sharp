using BookShop.Data;
using BookShop.Initializer;
using System;
using System.Linq;
using System.Text;

namespace BookShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //1.Age Restriction
            string command = Console.ReadLine();
            Console.WriteLine(GetBooksByAgeRestriction(db, command));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var booksTitle = context.Books.ToList()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => new { Title = b.Title })
                .OrderBy(b => b.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var title in booksTitle)
            {
                sb.AppendLine(title.Title);
            }

            return sb.ToString().Trim();
        }
    }
}
