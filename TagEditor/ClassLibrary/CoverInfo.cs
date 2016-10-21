using System;
using System.Drawing;

namespace Shared
{
    public class CoverInfo
    {
        public string Url { get; set; }
        public Image Image { get; set; }
        public long FileSize { get; set; }
        public int Index { get; set; }
        public int TotalCount { get; set; }

        public override string ToString()
        {
            return "Resolution: " + this.Image.Width + " x " + this.Image.Height + Environment.NewLine
                   + "FileSize: " + this.FileSize + " bytes" + Environment.NewLine
                   + "Index: " + (this.Index + 1) + " / "  + this.TotalCount + Environment.NewLine
                   + "Url: " + this.Url + Environment.NewLine;
        }
    }
}
