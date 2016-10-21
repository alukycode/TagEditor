using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LastFmApi.ApiModels;

namespace LastFmApi.ApiMethods
{
    public static class ArtistMethods
    {
        // artist (Required (unless mbid)] : The artist name
        // mbid (Optional) : The musicbrainz id for the artist
        // lang (Optional) : The language to return the biography in, expressed as an ISO 639 alpha-2 code.
        // autocorrect[0|1] (Optional) : Transform misspelled artist names into correct artist names, returning the correct version instead. The corrected artist name will be returned in the response.
        // username (Optional) : The username for the context of the request. If supplied, the user's playcount for this artist is included in the response.
        // api_key (Required) : A Last.fm API key.
        public static Artist GetInfo(string artist)
        {
            const string method = "track.getInfo";

            var arguments = new Dictionary<string, string>
            {
                { "artist", artist },
                { "autocorrect", "1" }
            };

            return RequestPerformer.PerformRequest<Artist>(method, arguments);
        }
    }
}
