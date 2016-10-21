using System;
using System.Collections.Generic;
using LastFmApi.ApiModels;

namespace LastFmApi.ApiMethods
{
    public static class TrackMethods
    {
        // mbid (Optional) : The musicbrainz id for the track
        // track (Required (unless mbid)] : The track name
        // artist (Required (unless mbid)] : The artist name
        // username (Optional) : The username for the context of the request. If supplied, the user's playcount for this track and whether they have loved the track is included in the response.
        // autocorrect[0|1] (Optional) : Transform misspelled artist and track names into correct artist and track names, returning the correct version instead. The corrected artist and track name will be returned in the response.
        // api_key (Required) : A Last.fm API key.
        public static Track GetInfo(string artist, string track)
        {
            const string method = "track.getInfo";

            var arguments = new Dictionary<string, string>
            {
                { "artist", artist },
                { "track", track },
                { "autocorrect", "1" }
            };

            return RequestPerformer.PerformRequest<Track>(method, arguments);
        }
    }
}
