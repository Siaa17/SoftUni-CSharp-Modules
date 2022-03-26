namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            StringReader reader = new StringReader(xmlString);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Books");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportBookDto[]), xmlRoot);

            ImportBookDto[] dtoBooks = (ImportBookDto[])xmlSerializer.Deserialize(reader);

            HashSet<Book> validBooks = new HashSet<Book>();

            foreach (ImportBookDto dtoBook in dtoBooks)
            {
                if (!IsValid(dtoBook))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime publishedOn = DateTime.ParseExact(dtoBook.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                Book book = new Book()
                {
                    Name = dtoBook.Name,
                    Genre = (Genre)dtoBook.Genre,
                    Price = dtoBook.Price,
                    Pages = dtoBook.Pages,
                    PublishedOn = publishedOn
                };

                validBooks.Add(book);

                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(validBooks);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<ImportAuthorDto> dtoAuthors = JsonConvert.DeserializeObject<ICollection<ImportAuthorDto>>(jsonString);

            HashSet<Author> validAuthors = new HashSet<Author>();

            foreach (ImportAuthorDto dtoAuthor in dtoAuthors)
            {
                if (!IsValid(dtoAuthor))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (validAuthors.Any(x => x.Email == dtoAuthor.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author()
                {
                    FirstName = dtoAuthor.FirstName,
                    LastName = dtoAuthor.LastName,
                    Phone = dtoAuthor.Phone,
                    Email = dtoAuthor.Email,                   
                };

                HashSet<AuthorBook> authorBooks = new HashSet<AuthorBook>();

                foreach (ImportAuthorBooksDto dtoBook in dtoAuthor.Books)
                {
                    Book book = context.Books.Find(dtoBook.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    AuthorBook authorBook = new AuthorBook()
                    {
                        Author = author,
                        Book = book
                    };

                    authorBooks.Add(authorBook);       
                }

                if (authorBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                author.AuthorsBooks = authorBooks;
                validAuthors.Add(author);

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, authorBooks.Count));
            }

            context.Authors.AddRange(validAuthors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}