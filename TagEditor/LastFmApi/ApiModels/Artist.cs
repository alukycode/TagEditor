using System.Xml.Serialization;

// ReSharper disable InconsistentNaming
namespace LastFmApi.ApiModels
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName="artist", Namespace = "", IsNullable = false)]
    public class Artist
    {
        public string name { get; set; }

        public string mbid { get; set; }

        public string url { get; set; }

        [XmlElement("image")]
        public artistImage[] image { get; set; }

        public byte streamable { get; set; }

        public byte ontour { get; set; }

        public artistStats stats { get; set; }

        [XmlArrayItem("artist", IsNullable = false)]
        public artistArtist[] similar { get; set; }

        [XmlArrayItem("tag", IsNullable = false)]
        public artistTag[] tags { get; set; }

        public artistBio bio { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class artistImage
    {
        [XmlAttribute]
        public string size { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class artistStats
    {
        public uint listeners { get; set; }

        public uint playcount { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class artistArtist
    {
        public string name { get; set; }

        public string url { get; set; }

        [XmlElement("image")]
        public artistArtistImage[] image { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class artistArtistImage
    {
        [XmlAttribute]
        public string size { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class artistTag
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class artistBio
    {
        public artistBioLinks links { get; set; }

        public string published { get; set; }

        public string summary { get; set; }

        public string content { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class artistBioLinks
    {
        public artistBioLinksLink link { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public class artistBioLinksLink
    {
        [XmlAttribute]
        public string rel { get; set; }

        [XmlAttribute]
        public string href { get; set; }
    }
}