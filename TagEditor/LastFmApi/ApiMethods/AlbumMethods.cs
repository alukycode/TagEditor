using System.Collections.Generic;
using LastFmApi.ApiModels;

namespace LastFmApi.ApiMethods
{
    public static class AlbumMethods
    {
        /// <summary>
        /// artist (Required (unless mbid)] : The artist name
        /// album (Required (unless mbid)] : The album name
        /// mbid (Optional) : The musicbrainz id for the album
        /// autocorrect[0|1] (Optional) : Transform misspelled artist names into correct artist names, returning the correct version instead. The corrected artist name will be returned in the response.
        /// username (Optional) : The username for the context of the request. If supplied, the user's playcount for this album is included in the response.
        /// lang (Optional) : The language to return the biography in, expressed as an ISO 639 alpha-2 code.
        /// api_key (Required) : A Last.fm API key.
        /// </summary>
        public static Album GetInfo(string artist, string album)
        {
            const string method = "album.getInfo";

            var arguments = new Dictionary<string, string>
            {
                { "artist", artist },
                { "album", album },
                { "autocorrect", "1" }
            };

            return RequestPerformer.PerformRequest<Album>(method, arguments);
        }
    }
}
