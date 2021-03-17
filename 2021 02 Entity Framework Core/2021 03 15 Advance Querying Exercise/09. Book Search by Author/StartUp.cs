using BookShop.Data;
using BookShop.Initializer;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            //string command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, command));

            //2. Golden Books
            //Console.WriteLine(GetGoldenBooks(db));

            //3.Books by Price
            //Console.WriteLine(GetBooksByPrice(db));

            //4. Not Released In
            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, year));

            //5. Book Titles by Category
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db, input));

            //6. Released Before Date
            //string date = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, date));

            //7. Author Search
            //string input = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

            //8. Book Search
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db, input));

            //9. Book Search by Author
            string input = Console.ReadLine();
            Console.WriteLine(GetBooksByAuthor(db, input));
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

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenEditionBooks = context.Books
                                .Where(b => b.Copies < 5000 &&
                                       b.EditionType == Models.Enums.EditionType.Gold)
                                .OrderBy(b => b.BookId)
                                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var title in goldenEditionBooks)
            {
                sb.AppendLine(title.Title);
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksByPrice = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookPrice = b.Price
                })
                .OrderByDescending(b => b.BookPrice)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.BookTitle} - ${book.BookPrice:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksNotReleased = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var book in booksNotReleased)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categoryList = input
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(c => c.ToLower())
                            .ToList();

            var bookByCategory = context.Books
                .Where(b => b.BookCategories
                            .Any(bc => categoryList.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in bookByCategory)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var convertedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksByRelease = context.Books
                .Where(b => b.ReleaseDate < convertedDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price,
                    ReleaseDate = b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var book in booksByRelease)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorsNames = context.Authors
                    .Where(a => a.FirstName.EndsWith(input))
                    .Select(a => new
                    {
                        FullName = a.FirstName + " " + a.LastName
                    })
                    .OrderBy(a => a.FullName)
                    .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authorsNames)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().Trim();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var inputIgnoreCasing = input.ToLower();

            var bookTitles = context.Books
                        .Where(b=>b.Title.ToLower().Contains(inputIgnoreCasing))
                        .Select(b => new
                        {
                            Title = b.Title
                        })
                        .OrderBy(b=>b.Title)
                        .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var title in bookTitles)
            {
                sb.AppendLine(title.Title);
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var inputIgnoreCasing = input.ToLower();

            var booksAuthor = context.Books
                        .Where(b => b.Author.LastName.ToLower().StartsWith(inputIgnoreCasing))
                        .Select(b => new
                        {
                            BookId = b.BookId,
                            Title = b.Title,
                            AuthorNames = b.Author.FirstName + " " + b.Author.LastName
                        })
                        .OrderBy(b=>b.BookId)
                        .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var output in booksAuthor)
            {
                sb.AppendLine($"{output.Title} ({output.AuthorNames})");
            }

            return sb.ToString().Trim();
        }
    }
}
