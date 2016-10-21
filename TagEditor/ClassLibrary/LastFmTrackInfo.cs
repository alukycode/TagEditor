using System;
using System.Collections.Generic;

namespace Shared
{
    public class LastFmTrackInfo
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }

        public string ArtistUrl { get; set; }
        public string TrackUrl { get; set; }

        public IList<string> Tags { get; set; }
        
        //public string AlbumPosition { get; set; }
        //public string Cover { get; set; } // albuminfo mega size cover

        public override string ToString()
        {
            return "Artist: " + this.Artist + Environment.NewLine
                   + "Title: " + this.Title + Environment.NewLine
                   + "Album: " + this.Album + Environment.NewLine
                   + "Tags: " + string.Join(", ", this.Tags) + Environment.NewLine;
        }
    }
}
