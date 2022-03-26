namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var gamesByGenres = context.Genres
                .ToList()
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games                   
                    .Select(g => new
                    {
                        Id = g.Id,
                        Title = g.Name,
                        Developer = g.Developer.Name,
                        Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
                        Players = g.Purchases.Count                        
                    })
                    .Where(g => g.Players > 0)
                    .OrderByDescending(g => g.Players)
                    .ThenBy(g => g.Id)
                    .ToList(),
                    TotalPlayers = x.Games.Sum(x => x.Purchases.Count)
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();

            string gamesByGenresAsJson = JsonConvert.SerializeObject(gamesByGenres, Formatting.Indented);

            return gamesByGenresAsJson;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportUserDto[] userPurchases = context.Users
                .ToArray()
                .Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    TotalSpent = u.Cards
                    .Sum(c => c.Purchases
                    .Where(p => p.Type.ToString() == storeType)
                    .Sum(p => p.Game.Price)),
                    Purchases = u.Cards.SelectMany(c => c.Purchases)
                    .Where(p => p.Type.ToString() == storeType)
                    .Select(p => new ExportUserPurchasesDto
                    {
                        Card = p.Card.Number,
                        CVC = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportGameDto
                        {
                            GameName = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .OrderBy(p => p.Date)
                    .ToArray()
                })
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            xmlSerializer.Serialize(writer, userPurchases, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}