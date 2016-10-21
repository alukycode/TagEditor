namespace Helpers
{
    using System.Drawing;
    using System.IO;
    using System.Net;

    using Shared;

    public static class CoverHelper
    {
        private static string _lastQuery = string.Empty;
        private static int _lastIndex = 0;

        private class DownloadedImageInfo
        {
            public Image Image { get; set; }
            public long FileSize { get; set; }
        }

        public static CoverInfo GetCover(string artist, string album)
        {
            var query = artist + " " + album + " cover";
            var imagesUrls = GoogleHelper.GetImagesUrls(query);

            var index = 0;
            if (_lastQuery == query)
            {
                _lastIndex++;
                if (_lastIndex >= imagesUrls.Count)
                    _lastIndex = 0;
                index = _lastIndex;
            }
            else
            {
                _lastQuery = query;
                _lastIndex = 0;
            }

            var url = imagesUrls[index];

            var imageInfo = DownloadImageFromUrl(url);

            var result = new CoverInfo
            {
                Url = url,
                Image = imageInfo.Image,
                FileSize = imageInfo.FileSize,
                Index = index,
                TotalCount = imagesUrls.Count
            };

            return result;
        }
        
        private static DownloadedImageInfo DownloadImageFromUrl(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                var result = new DownloadedImageInfo
                {
                    Image = Image.FromStream(memoryStream),
                    FileSize = memoryStream.Length
                };

                return result;
            }
        }
    }
}
