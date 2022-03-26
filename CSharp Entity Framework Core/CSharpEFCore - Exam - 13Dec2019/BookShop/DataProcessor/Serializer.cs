namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var mostCraziestAuthors = context.Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    Books = a.AuthorsBooks
                   .OrderByDescending(a => a.Book.Price)
                   .Select(ab => new
                   {
                       BookName = ab.Book.Name,
                       BookPrice = ab.Book.Price.ToString("F2")
                   })
                   .ToList()
                })
                .ToList()
                .OrderByDescending(x => x.Books.Count)
                .ThenBy(x => x.AuthorName)
                .ToList();
                

            string authorsAsJson = JsonConvert.SerializeObject(mostCraziestAuthors, Formatting.Indented);

            return authorsAsJson;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Books");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportBookDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);


            var oldestBooks = context.Books
                .ToArray()
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.PublishedOn)
                .Select(b => new ExportBookDto
                {
                    BookName = b.Name,
                    PublishedOn = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                    Pages = b.Pages
                })
                .Take(10)
                .ToArray();

            xmlSerializer.Serialize(writer, oldestBooks, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}