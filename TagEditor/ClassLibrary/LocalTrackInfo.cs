using System;
using System.Drawing;

namespace Shared
{
    public class LocalTrackInfo
    {
        public string Path { get; protected set; }

        public string Artist { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public uint Year { get; set; }
        public string Genre { get; set; }
        public Image Cover { get; set; }
        public string Lyrics { get; set; }

        public LocalTrackInfo(string path)
        {
            this.Path = path;
        }

        public override string ToString()
        {
            return "Artist: " + this.Artist + Environment.NewLine
                   + "Title: " + this.Title + Environment.NewLine
                   + "Album: " + this.Album + Environment.NewLine
                   + "Year: " + this.Year + Environment.NewLine
                   + "Genre: " + this.Genre + Environment.NewLine;
        }
    }
}
