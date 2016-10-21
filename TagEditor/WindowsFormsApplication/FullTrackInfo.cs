using Shared;

namespace WindowsFormsApplication
{
    public class FullTrackInfo
    {
        public string Path;

        public LocalTrackInfo LocalInfo { get; set; }
        public LastFmTrackInfo LastFmInfo { get; set; }

        public FullTrackInfo(string path)
        {
            this.Path = path;
        }
    }
}
