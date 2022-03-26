namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			ICollection<ImportGameDto> dtoGames = JsonConvert.DeserializeObject<ICollection<ImportGameDto>>(jsonString);

            foreach (ImportGameDto dtoGame in dtoGames)
            {
                if (!IsValid(dtoGame) || dtoGame.Tags.Count == 0)
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				Developer developer = context.Developers.FirstOrDefault(x => x.Name == dtoGame.Developer) ?? new Developer() { Name = dtoGame.Developer };

				Genre genre = context.Genres.FirstOrDefault(x => x.Name == dtoGame.Genre) ?? new Genre() { Name = dtoGame.Genre };

				Game game = new Game()
				{
					Name = dtoGame.Name,
					Price = dtoGame.Price,
					ReleaseDate = dtoGame.ReleaseDate.Value,
					Developer = developer,
					Genre = genre
				};

				foreach (string dtoTag in dtoGame.Tags)
				{
					Tag tag = context.Tags.FirstOrDefault(x => x.Name == dtoTag) ?? new Tag() { Name = dtoTag };

					game.GameTags.Add(new GameTag() { Tag = tag });
				}

				context.Games.Add(game);
				context.SaveChanges();

				sb.AppendLine($"Added {dtoGame.Name} ({dtoGame.Genre}) with {dtoGame.Tags.Count} tags");
			}

			return sb.ToString().TrimEnd();
		}

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
			StringBuilder sb = new StringBuilder();

			ICollection<ImportUserDto> dtoUsers = JsonConvert.DeserializeObject<ICollection<ImportUserDto>>(jsonString);

			HashSet<User> validUsers = new HashSet<User>();

            foreach (ImportUserDto dtoUser in dtoUsers)
            {
                if (!IsValid(dtoUser) || !dtoUser.Cards.All(IsValid))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				User user = new User()
				{
					FullName = dtoUser.FullName,
					Username = dtoUser.Username,
					Email = dtoUser.Email,
					Age = dtoUser.Age,
					Cards = dtoUser.Cards
					.Select(c => new Card
					{
						Number = c.Number,
						Cvc = c.CVC,
						Type = c.Type.Value,
					})
					.ToList()
				};

				validUsers.Add(user);

				sb.AppendLine($"Imported {dtoUser.Username} with {dtoUser.Cards.Count} cards");
            }

			context.Users.AddRange(validUsers);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
			StringBuilder sb = new StringBuilder();
			StringReader reader = new StringReader(xmlString);

			XmlRootAttribute xmlRoot = new XmlRootAttribute("Purchases");
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), xmlRoot);

			ImportPurchaseDto[] dtoPurchases = (ImportPurchaseDto[])xmlSerializer.Deserialize(reader);

			HashSet<Purchase> validPurchase = new HashSet<Purchase>();

            foreach (ImportPurchaseDto dtoPurchase in dtoPurchases)
            {
                if (!IsValid(dtoPurchase))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				bool isDateValid = DateTime.TryParseExact(
					dtoPurchase.Date, "dd/MM/yyyy HH:mm",
					CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

				if (!isDateValid)
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				Purchase purchase = new Purchase()
				{
					Game = context.Games.FirstOrDefault(x => x.Name == dtoPurchase.GameName),
					Type = dtoPurchase.Type.Value,
					ProductKey = dtoPurchase.ProductKey,
					Card = context.Cards.FirstOrDefault(x => x.Number == dtoPurchase.Card),
					Date = date,
				};

				validPurchase.Add(purchase);

				string username = context.Users.Where(x => x.Id == purchase.Card.UserId)
					.Select(x => x.Username).FirstOrDefault();

				sb.AppendLine($"Imported {dtoPurchase.GameName} for {username}");
            }

			context.Purchases.AddRange(validPurchase);
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