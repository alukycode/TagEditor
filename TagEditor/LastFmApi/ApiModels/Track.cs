using System.Xml.Serialization;

// ReSharper disable InconsistentNaming
namespace LastFmApi.ApiModels
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName="track", Namespace = "", IsNullable = false)]
    public class Track
    {
        public string name { get; set; }

        public string mbid { get; set; }

        public string url { get; set; }

        public uint duration { get; set; }

        public trackStreamable streamable { get; set; }

        public uint listeners { get; set; }

        public uint playcount { get; set; }

        public trackArtist artist { get; set; }

        public trackAlbum album { get; set; }

        [XmlArrayItem("tag", IsNullable = false)]
        public trackTag[] toptags { get; set; }

        public trackWiki wiki { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class trackStreamable
    {
        [XmlAttribute]
        public byte fulltrack { get; set; }

        [XmlText]
        public byte Value { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class trackArtist
    {
        public string name { get; set; }

        public string mbid { get; set; }

        public string url { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class trackAlbum
    {
        public string artist { get; set; }

        public string title { get; set; }

        public string mbid { get; set; }

        public string url { get; set; }

        [XmlElement("image")]
        public trackAlbumImage[] image { get; set; }

        [XmlAttribute]
        public byte position { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class trackAlbumImage
    {
        [XmlAttribute]
        public string size { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class trackTag
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class trackWiki
    {
        public string published { get; set; }

        public string summary { get; set; }

        public string content { get; set; }
    }
}