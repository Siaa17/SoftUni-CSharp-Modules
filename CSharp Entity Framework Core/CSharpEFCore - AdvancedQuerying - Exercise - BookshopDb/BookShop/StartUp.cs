namespace BookShop
{
    using System;
    using Data;
    using Initializer;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using BookShop.Models.Enums;
    using System.Globalization;
    using BookShop.Models;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //string inputCmd = Console.ReadLine();

            //string result = GetBooksByAgeRestriction(db, inputCmd);
            //string result = GetGoldenBooks(db);
            //string result = GetBooksByPrice(db);

            //int year = int.Parse(Console.ReadLine());
            //string result = GetBooksNotReleasedIn(db, year);

            //string input = Console.ReadLine();
            //string result = GetBooksByCategory(db, input);

            //string date = Console.ReadLine();
            //string result = GetBooksReleasedBefore(db, date);

            //string input = Console.ReadLine();
            //string result = GetAuthorNamesEndingIn(db, input);

            //string input = Console.ReadLine();
            //string result = GetBookTitlesContaining(db, input);

            //string input = Console.ReadLine();
            //string result = GetBooksByAuthor(db, input);

            //int lengthCheck = int.Parse(Console.ReadLine());
            //int result = CountBooks(db, lengthCheck);

            //string result = CountCopiesByAuthor(db);

            //string result = GetTotalProfitByCategory(db);

            //string result = GetMostRecentBooks(db);
            //Console.WriteLine(result);

            //IncreasePrices(db);

            int result = RemoveBooks(db);
            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            List<string> bookTitles = context.Books
                .ToList()
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            foreach (string bookTitle in bookTitles)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            EditionType editionType = Enum.Parse<EditionType>("Gold");

            List<string> goldenBooks = context.Books
                .Where(gb => gb.Copies < 5000 &&
                gb.EditionType == editionType)
                .OrderBy(gb => gb.BookId)
                .Select(gb => gb.Title)
                .ToList();

            foreach (string goldenBook in goldenBooks)
            {
                sb.AppendLine(goldenBook);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksByPrice = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            List<string> notReleasedInBooks = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            foreach (string bookTitle in notReleasedInBooks)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            List<string> categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> booksByCategory = context.BooksCategories
                .Where(bc => categories.Any(c => c == bc.Category.Name.ToLower()))
                .OrderBy(bc => bc.Book.Title)
                .Select(bc => bc.Book.Title)
                .ToList();

            foreach (string book in booksByCategory)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksReleasedBeforeGivenDate = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Date < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            foreach (var book in booksReleasedBeforeGivenDate)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authorNamesEndingIn = context.Authors
                .ToList()
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.FullName)
                .ToList();

            foreach (var author in authorNamesEndingIn)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            List<string> bookTitlesContainingGivenString = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            foreach (string bookTitle in bookTitlesContainingGivenString)
            {
                sb.AppendLine(bookTitle);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var booksByAuthor = context.Books
                .Where(ba => ba.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title,
                    AuthorFullName = $"{x.Author.FirstName} {x.Author.LastName}"
                })
                .ToList();

            foreach (var book in booksByAuthor)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int countBooks = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .ToList()
                .Count;

            return countBooks;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var countCopiesByAuthor = context.Authors
                .Select(x => new
                {
                    AuthorFullName = $"{x.FirstName} {x.LastName}",
                    TotalBookCopies = x.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(x => x.TotalBookCopies)
                .ToList();

            foreach (var author in countCopiesByAuthor)
            {
                sb.AppendLine($"{author.AuthorFullName} - {author.TotalBookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksTotalProfit = context.Categories
                .Select(c => new
                {                    
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price),
                    CategoryName = c.Name
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.CategoryName)
                .ToList();

            foreach (var book in booksTotalProfit)
            {
                sb.AppendLine($"{book.CategoryName} ${book.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var mostRecentBooks = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    BookInfo = c.CategoryBooks
                    .Select(x => new 
                    {
                        BookTitle = x.Book.Title,
                        ReleaseDate = x.Book.ReleaseDate
                    })
                    .OrderByDescending(x => x.ReleaseDate)
                    .Take(3)
                })
                .OrderBy(x => x.CategoryName)                
                .ToList();

            foreach (var recentBook in mostRecentBooks)
            {
                sb.AppendLine($"--{recentBook.CategoryName}");

                foreach (var book in recentBook.BookInfo)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseDate.Value.Year})");
                }                   
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            IQueryable<Book> booksReleasedBefore2010 = context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year < 2010);

            foreach (Book book in booksReleasedBefore2010)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            List<Book> removedBooks = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.RemoveRange(removedBooks);

            context.SaveChanges();

            return removedBooks.Count;
        }
    }
}
