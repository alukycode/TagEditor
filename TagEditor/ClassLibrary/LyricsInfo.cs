using System;

namespace Shared
{
    public class LyricsInfo
    {
        public string Url { get; set; }
        public string Lyrics { get; set; }
        public int Index { get; set; }
        public int SubIndex { get; set; }
        public int TotalCount { get; set; }

        public override string ToString()
        {
            return "Length: " + this.Lyrics.Length + Environment.NewLine
                   + "Index: " + (this.Index + 1) + "." + this.SubIndex + " / " + this.TotalCount + Environment.NewLine
                   + "Url: " + this.Url;
        }
    }
}
