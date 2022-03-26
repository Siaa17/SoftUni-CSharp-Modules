namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            //string result = ExportAlbumsInfo(context, 9);
            //Console.WriteLine(result);

            string result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albumsInfo = context.Albums
                .ToList()
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
                        Price = s.Price,
                        Writer = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.Writer),
                    TotalAlbumPrice = a.Price
                })
                .ToList();

            foreach (var album in albumsInfo)
            {
                sb
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                int i = 1;

                foreach (var song in album.Songs)
                {
                    sb
                        .AppendLine($"---#{i++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price:F2}")
                        .AppendLine($"---Writer: {song.Writer}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songsAboveDuration = context.Songs
                .ToList()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,                   
                    Performer = s.SongPerformers
                    .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                    .FirstOrDefault(),
                    Writer = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c", CultureInfo.InvariantCulture)
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToList();

            int i = 1;

            foreach (var song in songsAboveDuration)
            {
                sb
                    .AppendLine($"-Song #{i++}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.Writer}")
                    .AppendLine($"---Performer: {song.Performer}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
