namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .OrderByDescending(x => x.NumberOfHalls)
                .ThenBy(x => x.Name)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                    .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Sum(x => x.Price),
                    Tickets = t.Tickets
                    .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                    .Select(x => new
                    {
                        Price = x.Price,
                        RowNumber = x.RowNumber
                    })
                    .OrderByDescending(x => x.Price)
                    .ToList()
                })
                .ToList();

            string theatresAsJson = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return theatresAsJson;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPlayDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportPlayDto[] playsDto = context.Plays
                .Where(p => p.Rating <= rating)
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .Select(p => new ExportPlayDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating.ToString(),
                    Genre = p.Genre,
                    Actors = p.Casts
                    .Where(x => x.IsMainCharacter == true)
                    .Select(a => new ExportActorDto
                    {
                        FullName = a.FullName,
                        MainCharacter = $"Plays main character in '{a.Play.Title}'."
                    })
                    .OrderByDescending(x => x.FullName)
                    .ToArray()

                })
                .ToArray();

            foreach (var play in playsDto)
            {
                if (play.Rating == "0")
                {
                    play.Rating = "Premier";
                }
            }

            xmlSerializer.Serialize(writer, playsDto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
