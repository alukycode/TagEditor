namespace Helpers
{
    using System.Drawing;
    using System.IO;

    using Shared;

    using TagLib;

    public static class TaglibHelper
    {

        public static Image ConvertPictureToImage(IPicture picture)
        {
            var ms = new MemoryStream(picture.Data.Data);
            return Image.FromStream(ms);
        }

        public static Picture ConvertImageToPicture(Image image)
        {
            var imageBytes = (byte[])new ImageConverter().ConvertTo(image, typeof(byte[]));
            var picture = new Picture(new TagLib.ByteVector(imageBytes));
            return picture;
        }

        public static LocalTrackInfo ScanFile(string path)
        {
            using(var tagLibFile = TagLib.File.Create(path))
            {
                var localTrackInfo = new LocalTrackInfo(path)
                {
                    Artist = tagLibFile.Tag.FirstPerformer,
                    Title = tagLibFile.Tag.Title,
                    Album = tagLibFile.Tag.Album,
                    Year = tagLibFile.Tag.Year,
                    Genre = tagLibFile.Tag.FirstGenre,
                    Cover = tagLibFile.Tag.Pictures.Length != 0 ? ConvertPictureToImage(tagLibFile.Tag.Pictures[0]) : null,
                    Lyrics = tagLibFile.Tag.Lyrics
                };

                return localTrackInfo;
            }
        }

        public static void SaveFile(LocalTrackInfo trackInfo)
        {
            using(var tagLibFile = TagLib.File.Create(trackInfo.Path))
            {
                //tagLibFile.Tag.Performers = null;
                tagLibFile.Tag.Performers = new[] { trackInfo.Artist };
                tagLibFile.Tag.Title = trackInfo.Title;
                tagLibFile.Tag.Album = trackInfo.Album;
                tagLibFile.Tag.Year = trackInfo.Year;
                tagLibFile.Tag.Genres = new[] { trackInfo.Genre };
                if (trackInfo.Cover != null)
                    tagLibFile.Tag.Pictures = new IPicture[] { ConvertImageToPicture(trackInfo.Cover) };
                tagLibFile.Tag.Lyrics = trackInfo.Lyrics;
                tagLibFile.Save();
            }
        }
    }
}
