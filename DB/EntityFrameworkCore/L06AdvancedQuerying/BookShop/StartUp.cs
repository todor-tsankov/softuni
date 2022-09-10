namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var titleNames = context.Books
                .Select(x => new { x.Title, x.AgeRestriction })
                .ToList();

            var filterredTitles = titleNames
                .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                .OrderBy(x => x.Title)
                .ToList();

            var sb = new StringBuilder();
            filterredTitles.ForEach(x => sb.AppendLine(x.Title));

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooksTitles = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            var sb = new StringBuilder();
            goldenBooksTitles.ForEach(x => sb.AppendLine(x));

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price >= 40)
                .Select(x => new { x.Title, x.Price })
                .OrderByDescending(x => x.Price)
                .ToList();

            var sb = new StringBuilder();
            books.ForEach(x => sb.AppendLine($"{x.Title} - ${x.Price:F2}"));

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var bookTitles = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            var sb = new StringBuilder();
            bookTitles.ForEach(x => sb.AppendLine(x));

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .ToLower()
                .Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var books = context.Books
                .Where(x => x.BookCategories.Select(x => x.Category.Name.ToLower()).Any(y => categories.Contains(y)))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var sb = new StringBuilder();
            books.ForEach(x => sb.AppendLine(x));

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
               .Where(x => x.ReleaseDate < dateTime)
               .OrderByDescending(x => x.ReleaseDate)
               .Select(x => new
               {
                   x.Title,
                   x.EditionType,
                   x.Price
               })
               .ToList();

            var sb = new StringBuilder();
            books.ForEach(x => sb.AppendLine($"{x.Title} - {x.EditionType} - ${x.Price:F2}"));

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => x.FirstName + " " + x.LastName)
                .OrderBy(x => x)
                .ToList();

            var sb = new StringBuilder();
            authorNames.ForEach(x => sb.AppendLine(x));

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var booktitles = context.Books
                .AsEnumerable()
                .Where(x => x.Title.Contains(input, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var sb = new StringBuilder();
            booktitles.ForEach(x => sb.AppendLine(x));

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                   x.Title,
                   x.Author.FirstName,
                   x.Author.LastName
                })
                .AsEnumerable()
                .Where(x => x.LastName.StartsWith(input, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            var sb = new StringBuilder();
            books.ForEach(x => sb.AppendLine($"{x.Title} ({x.FirstName} {x.LastName})"));

            return sb
                .ToString()
                .TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    CountCopies = x.Books
                        .Select(y => y.Copies)
                        .Sum()
                })
                .OrderByDescending(x => x.CountCopies)
                .ToList();

            var sb = new StringBuilder();
            authors.ForEach(x => sb.AppendLine($"{x.FullName} - {x.CountCopies}"));

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Profit = x.CategoryBooks
                        .Select(y => y.Book)
                        .Select(z => z.Copies * z.Price)
                        .Sum()
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToList();

            var sb = new StringBuilder();
            categories.ForEach(x => sb.AppendLine($"{x.Name} ${x.Profit:F2}"));

            return sb
                .ToString()
                .TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    MostRescentBooks = x.CategoryBooks
                        .Select(y => y.Book)
                        .OrderByDescending(z => z.ReleaseDate.Value)
                        .Select(z => new
                        {
                            BookTitle = z.Title,
                            Year = z.ReleaseDate.Value.Year
                        })
                        .Take(3)
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var cat in categories)
            {
                sb.AppendLine($"--{cat.CategoryName}");

                foreach (var book in cat.MostRescentBooks)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.Year})");
                }
            }

            return sb
                .ToString()
                .TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            books.ForEach(x => x.Price += 5);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(booksToRemove);
            context.SaveChanges();

            return booksToRemove.Count;
        }
    }
}
