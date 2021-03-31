namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var gamesByGenres = context.Genres
                .ToList()
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games.Where(gm => gm.Purchases.Count > 0)
                    .Select(gs => new
                    {
                        Id = gs.Id,
                        Title = gs.Name,
                        Developer = gs.Developer.Name,
                        Tags = string.Join(", ", gs.GameTags.Select(t => t.Tag.Name)),
                        Players = gs.Purchases.Count
                    })
                    .OrderByDescending(gs => gs.Players)
                    .ThenBy(gs => gs.Id)
                    .ToList(),
                    TotalPlayers = g.Games.Sum(p => p.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(gamesByGenres, Formatting.Indented);

            return jsonResult;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var usersDto = context.Users.ToList()
                .Where(u => u.Cards.Any(p => p.Purchases.Count > 0))
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    Purchases = context.Purchases.ToList()
                        .Where(p => p.Card.User.Username == u.Username && p.Type == Enum.Parse<PurchaseType>(storeType))
                        .Select(p => new ExportPurchaseDto
                        {
                            CardNumber = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameDto
                            {
                                GameName = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
                        })
                        .OrderBy(p => p.Date)
                        .ToList(),
                    TotalSpent = context.Purchases.ToList()
                        .Where(p => p.Card.User.Username == u.Username && p.Type == Enum.Parse<PurchaseType>(storeType))
                        .Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchases.Count > 0)
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToList();

            var xmlRoot = new XmlRootAttribute("Users");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportUserDto>), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), usersDto, namespaces);

            return sb.ToString().Trim();
        }
    }
}