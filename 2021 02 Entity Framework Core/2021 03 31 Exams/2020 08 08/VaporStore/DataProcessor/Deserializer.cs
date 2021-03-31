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
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Game> games = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            var gamesDto = JsonConvert.DeserializeObject<List<ImportGameDto>>(jsonString);

            foreach (var gameDto in gamesDto)
            {
                DateTime releaseDate;
                var isValidDate = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (!IsValid(gameDto) || gameDto.Tags.Count == 0 || !isValidDate)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate
                };

                var devloper = developers.FirstOrDefault(d => d.Name == gameDto.Developer);
                var genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);

                if (devloper == null)
                {
                    devloper = new Developer
                    {
                        Name = gameDto.Developer
                    };

                    developers.Add(devloper);
                }

                game.Developer = devloper;

                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = gameDto.Genre
                    };

                    genres.Add(genre);
                }

                game.Genre = genre;

                foreach (var tagDto in gameDto.Tags)
                {
                    var tag = tags.FirstOrDefault(t => t.Name == tagDto);

                    if (tag == null)
                    {
                        tag = new Tag
                        {
                            Name = tagDto
                        };

                        tags.Add(tag);
                    }

                    game.GameTags.Add(new GameTag
                    {
                        Game = game,
                        Tag = tag
                    });
                }

                games.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersDto = JsonConvert.DeserializeObject<List<ImportUSerDto>>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<User> users = new List<User>();
            List<Card> cards = new List<Card>();

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User()
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                foreach (var cardDto in userDto.Cards)
                {
                    var card = new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = Enum.Parse<CardType>(cardDto.Type)
                    };

                    user.Cards.Add(card);
                }

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var xmlRoot = new XmlRootAttribute("Purchases");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportPurchasesDto>), xmlRoot);

            var purchasesDto = (List<ImportPurchasesDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();

            var purchases = new List<Purchase>();

            foreach (var purchaseDto in purchasesDto)
            {
                DateTime currentDate;
                var isValidDate = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out currentDate);

                Game game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Game);

                Card card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);

                if (!IsValid(purchaseDto) || !isValidDate || game == null || card == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Purchase purchase = new Purchase()
                {
                    Type = Enum.Parse<PurchaseType>(purchaseDto.Type),
                    ProductKey = purchaseDto.ProductKey,
                    Date = currentDate,
                    Game = game,
                    Card = card
                };

                purchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}