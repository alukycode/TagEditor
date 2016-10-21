namespace Helpers
{
    using System.Linq;
    using System.Threading.Tasks;

    using LastFmApi.ApiMethods;

    using Shared;

    public static class LastFmHelper
    {
        public static LastFmTrackInfo GetTrackInfo(string artist, string title)
        {
            var apiTrackInfo = TrackMethods.GetInfo(artist, title);

            var trackInfo = new LastFmTrackInfo
            {
                Artist = apiTrackInfo.artist.name,
                ArtistUrl = apiTrackInfo.artist.url,
                Title = apiTrackInfo.name,
                TrackUrl = apiTrackInfo.url,
                Album = apiTrackInfo.album != null ? apiTrackInfo.album.title : string.Empty,
                Tags = apiTrackInfo.toptags.Select(x => x.name).ToList()
            };

            return trackInfo;
        }

        public static async Task<LastFmTrackInfo> GetTrackInfoAsync(string artist, string title)
        {
            return await Task.Run(() => GetTrackInfo(artist, title));

            //var task = new Task<LastFmTrackInfo>(() => GetTrackInfo(artist, title));
            //task.Start();
            //return await task;
        }
    }
}
