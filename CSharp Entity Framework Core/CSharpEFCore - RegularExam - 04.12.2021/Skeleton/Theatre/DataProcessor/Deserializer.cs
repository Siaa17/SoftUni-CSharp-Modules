namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            StringReader reader = new StringReader(xmlString);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);

            ImportPlayDto[] playsDto = (ImportPlayDto[])xmlSerializer.Deserialize(reader);

            HashSet<Play> plays = new HashSet<Play>();

            foreach (ImportPlayDto playDto in playsDto)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDurationValid = TimeSpan.TryParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan duration);

                if (!isDurationValid || duration.TotalHours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = Enum.Parse<Genre>(playDto.Genre),
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                plays.Add(play);

                sb.AppendLine(string.Format(SuccessfulImportPlay, playDto.Title, playDto.Genre, playDto.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            StringReader reader = new StringReader(xmlString);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);

            ImportCastDto[] castsDto = (ImportCastDto[])xmlSerializer.Deserialize(reader);

            HashSet<Cast> casts = new HashSet<Cast>();

            foreach (ImportCastDto castDto in castsDto)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                casts.Add(cast);

                string characterType = castDto.IsMainCharacter ? "main" : "lesser";

                sb.AppendLine(string.Format(SuccessfulImportActor, castDto.FullName, characterType));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<ImportProjectionDto> projectionsDto = JsonConvert.DeserializeObject<ICollection<ImportProjectionDto>>(jsonString);

            HashSet<Theatre> theatres = new HashSet<Theatre>();

            foreach (ImportProjectionDto projectionDto in projectionsDto)
            {
                if (!IsValid(projectionDto) || projectionDto.Name == "")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre()
                {
                    Name = projectionDto.Name,
                    NumberOfHalls = projectionDto.NumberOfHalls,
                    Director = projectionDto.Director         
                };

                foreach (ImportTicketDto ticketDto in projectionDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    theatre.Tickets.Add(ticket);
                }

                theatres.Add(theatre);

                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
