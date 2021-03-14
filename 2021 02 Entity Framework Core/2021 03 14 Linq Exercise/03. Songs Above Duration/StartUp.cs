namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //02. Albums 
            // Console.WriteLine(ExportAlbumsInfo(context, 9));

            //03. Songs Above Duration
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(p => p.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate
                                .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price,
                        Writer = s.Writer.Name,
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.Writer)
                    .ToList(),
                    AlbumPrice = a.Price
                }).ToList()
                .OrderByDescending(a => a.AlbumPrice)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                int count = 1;
                sb
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                foreach (var song in album.Songs)
                {
                    sb
                        .AppendLine($"---#{count}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price:F2}")
                        .AppendLine($"---Writer: {song.Writer}");

                    count++;
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs.ToList()
                 .Where(s => s.Duration.TotalSeconds > duration)
                 .Select(s => new
                 {
                     Name = s.Name,
                     PerformerFullName = s.SongPerformers
                                   .Select(p =>  p.Performer.FirstName + " " + p.Performer.LastName )
                                   .FirstOrDefault(),
                     WriterName = s.Writer.Name,
                     AlbumProducer = s.Album.Producer.Name,
                     Duration = s.Duration
                 })
                 .ToList()
                 .OrderBy(s => s.Name)
                 .ThenBy(s => s.WriterName)
                 .ThenBy(s => s.PerformerFullName)
                 .ToList();

            StringBuilder sb = new StringBuilder();

            int count = 1;

            foreach (var song in songs)
            {
                sb
                    .AppendLine($"-Song #{count}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.WriterName}")
                    .AppendLine($"---Performer: {song.PerformerFullName}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration.ToString("c")}");

                    count++;
            }

            return sb.ToString().Trim();
        }
    }
}
