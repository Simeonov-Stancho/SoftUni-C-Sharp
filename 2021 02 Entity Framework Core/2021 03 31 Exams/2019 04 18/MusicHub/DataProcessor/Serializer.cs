namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            //order by price or by string?
            //with culture or?

            var albums = context.Albums.ToList()
                 .Where(a => a.ProducerId == producerId)
                 .OrderByDescending(a => a.Price)
                 .Select(a => new
                 {
                     AlbumName = a.Name,
                     ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                     ProducerName = a.Producer.Name,
                     Songs = a.Songs
                         .Select(s => new
                         {
                             SongName = s.Name,
                             Price = s.Price.ToString("F2"),
                             Writer = s.Writer.Name
                         })
                         .OrderByDescending(s => s.SongName)
                         .ThenBy(s => s.Writer)
                         .ToList(),
                     AlbumPrice = a.Price.ToString("F2")
                 }).ToList();

            string jsonSongs = JsonConvert.SerializeObject(albums, Formatting.Indented);

            return jsonSongs.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songResult = context.Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new ExportSongDto
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers
                    .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName).FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString(@"hh\:mm\:ss")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToList();

            var xmlRoot = new XmlRootAttribute("Songs");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportSongDto>), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            StringBuilder sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), songResult, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}