using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LastFmApi
{
    internal static class RequestPerformer
    {
        private static readonly string rootUrl;
        private static readonly string apiKey;
        private static readonly string apiSig;

        static RequestPerformer()
        {
            rootUrl = ConfigurationManager.AppSettings["LastFmRootUrl"];
            apiKey = ConfigurationManager.AppSettings["LastFmApiKey"];
            apiSig = ConfigurationManager.AppSettings["LastFmSharedSecret"];
        }

        public static T PerformRequest<T>(string method, Dictionary<string, string> arguments) where T : class
        {
            // 1. generating request url
            string url = rootUrl + "?method=" + method + "&api_key=" + apiKey;
            foreach (var argument in arguments)
            {
                url += "&" + argument.Key + "=" + argument.Value; // todo: argument values should be url-incoded
            }

            // 2. perform request and load it to XDocument
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            var document = XDocument.Load(responseStream);
            response.Close();

            // 3. check if error response
            if (document.Root.FirstAttribute.Value != "ok")
            {
                throw new Exception("last.fm response status = 'failed'");
            }

            // 4. deserialize response
            var element = document.Elements().Elements().First();
            XmlReader reader = element.CreateReader();
            var xmlSerializer = new XmlSerializer(typeof (T));
            var deserializedObject = xmlSerializer.Deserialize(reader);
            reader.Close(); // todo: using keyword
            return (T)deserializedObject;
        }
    }
}
