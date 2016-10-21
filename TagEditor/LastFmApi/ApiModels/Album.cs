using System.Xml.Serialization;

// ReSharper disable InconsistentNaming
namespace LastFmApi.ApiModels
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName="album", Namespace = "", IsNullable = false)]
    public class Album
    {
        public string name { get; set; }

        public string artist { get; set; }

        public string mbid { get; set; }

        public string url { get; set; }

        [XmlElement("image")]
        public albumImage[] image { get; set; }

        public uint listeners { get; set; }

        public uint playcount { get; set; }

        [XmlArrayItem("track", IsNullable = false)]
        public albumTrack[] tracks { get; set; }

        [XmlArrayItem("tag", IsNullable = false)]
        public albumTag[] tags { get; set; }

        public albumWiki wiki { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class albumImage
    {
        [XmlAttribute]
        public string size { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class albumTrack
    {
        public string name { get; set; }

        public string url { get; set; }

        public ushort duration { get; set; }

        public albumTrackStreamable streamable { get; set; }

        public albumTrackArtist artist { get; set; }

        [XmlAttribute]
        public byte rank { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class albumTrackStreamable
    {
        [XmlAttribute]
        public byte fulltrack { get; set; }

        [XmlText]
        public byte Value { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class albumTrackArtist
    {
        public string name { get; set; }

        public string mbid { get; set; }

        public string url { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class albumTag
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class albumWiki
    {
        public string published { get; set; }

        public string summary { get; set; }

        public string content { get; set; }
    }
}