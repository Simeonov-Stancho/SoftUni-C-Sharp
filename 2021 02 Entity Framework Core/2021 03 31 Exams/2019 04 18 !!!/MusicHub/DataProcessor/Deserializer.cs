namespace MusicHub.DataProcessor
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
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDto = JsonConvert.DeserializeObject<List<ImportWriterDto>>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Writer> writers = new List<Writer>();

            foreach (var writerDto in writersDto)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                writers.Add(writer);
                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<List<ImportProducerAlbumDto>>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Producer> producers = new List<Producer>();

            foreach (var producerDto in producersDto)
            {
                if (!IsValid(producerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber,
                };

                var isValidAlbum = true;

                foreach (var albumDto in producerDto.Albums)
                {
                    DateTime releaseDate;

                    var isValidDate = DateTime.TryParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                    if (!IsValid(albumDto) || !isValidDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        isValidAlbum = false;
                        break;
                    }

                    var album = new Album
                    {
                        Name = albumDto.Name,
                        ReleaseDate = releaseDate,
                        ProducerId = producer.Id,
                        Producer = producer
                    };

                    producer.Albums.Add(album);
                }

                if (isValidAlbum)
                {
                    if (producer.PhoneNumber != null)
                    {
                        sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count));
                    }

                    else
                    {
                        sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count));

                    }

                    producers.Add(producer);
                }
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Songs");

            var xmlSerializer = new XmlSerializer(typeof(List<ImportSongDto>), xmlRoot);

            var songsDto = (List<ImportSongDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            var songs = new List<Song>();

            foreach (var songDto in songsDto)
            {
                DateTime createdOn;
                var isValidDate = DateTime.TryParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out createdOn);

                TimeSpan duration;
                var isValidDuration = TimeSpan.TryParseExact(songDto.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture, out duration);

                var album = context.Albums.FirstOrDefault(a => a.Id == songDto.AlbumId);

                var writer = context.Writers.FirstOrDefault(w => w.Id == songDto.WriterId);

                if (!IsValid(songDto) || !isValidDate || !isValidDuration || album == null || writer == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = songDto.Name,
                    Duration = duration,
                    CreatedOn = createdOn,
                    Genre = Enum.Parse<Genre>(songDto.Genre),
                    AlbumId = songDto.AlbumId,
                    Album = album,
                    WriterId = songDto.WriterId,
                    Writer = writer,
                    Price = songDto.Price
                };

                songs.Add(song);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Performers");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportSongPerformerDto>), xmlRoot);

            var songPerformersDto = (List<ImportSongPerformerDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            var songPerformers = new List<Performer>();

            foreach (var songPerfDto in songPerformersDto)
            {
                if (!IsValid(songPerfDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var songPerformer = new Performer
                {
                    FirstName = songPerfDto.FirstName,
                    LastName = songPerfDto.LastName,
                    Age = songPerfDto.Age,
                    NetWorth = songPerfDto.NetWorth,
                };

                var isValidSong = true;

                foreach (var songIdDto in songPerfDto.PerformersSongs)
                {
                    if (!IsValid(songIdDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var song = context.Songs.FirstOrDefault(sp => sp.Id == songIdDto.Id);

                    //invalid song id do not import the performer too?
                    if (song == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        isValidSong = false;
                        break;
                    }

                    songPerformer.PerformerSongs.Add(new SongPerformer
                    {
                        Song = song,
                        SongId = song.Id,
                        Performer = songPerformer,
                        PerformerId = songPerformer.Id
                    });
                }

                if (isValidSong)
                {
                    songPerformers.Add(songPerformer);
                    sb.AppendLine(string.Format(SuccessfullyImportedPerformer, songPerformer.FirstName, songPerformer.PerformerSongs.Count));
                }
            }

            context.Performers.AddRange(songPerformers);
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