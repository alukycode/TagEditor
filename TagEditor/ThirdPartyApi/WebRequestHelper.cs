namespace Helpers
{
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;

    public static class WebRequestHelper
    {
        // WebBrowser is a GUI control used to visualize web page

        /*
            I had speed problem with WebRequest. Try setting Proxy = null;

            WebClient wc = new WebClient();
            wc.Proxy = null;

            By default WebClient, WebRequest try to determine what proxy to use from IE settings,
            sometimes it results in like 5 sec delay before the actual request is sent.

            This applies to all classes that use WebRequest, including WCF services with HTTP binding.
            In general you can use this static code at application startup:

            WebRequest.DefaultWebProxy = null;
        */

        // weblient open read - stream
        public static void GetSiteText_1()
        {
            var web = new WebClient();
            System.IO.Stream stream = web.OpenRead("http://www.yoursite.com/resource.txt");
            using (var reader = new System.IO.StreamReader(stream))
            {
                string text = reader.ReadToEnd();
            }
        }

        // webclient - download data - byte[]
        public static void GetSiteText_2()
        {
            var wc = new System.Net.WebClient();
            byte[] raw = wc.DownloadData("http://www.yoursite.com/resource/file.htm");

            string webData = System.Text.Encoding.UTF8.GetString(raw);
        }

        // webclient - download string - string
        public static string DownloadSiteHtml(string url)
        {
            string html = string.Empty;

            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.86 Safari/537.36");
                client.Encoding = Encoding.UTF8;

                try
                {
                    html = client.DownloadString(url);
                }
                catch
                {
                    html = string.Empty;
                }
            }

            return html;
        }

        // trying to fight with google 503 error
        public static string GetSiteTextFromGoogle(string url)
        {
            string html = string.Empty;

            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                client.Encoding = Encoding.UTF8;

                try
                {
                    html = client.DownloadString(url);
                }
                catch (WebException e)
                {
                    if (e.Response != null)
                    {
                        var stream = e.Response.GetResponseStream();
                        if (stream != null)
                        {
                            using (var sr = new StreamReader(stream))
                            {
                                html = sr.ReadToEnd();
                            }

                            // 1. enter captcha

                            //var id = "12451969833173998975";
                            //var captcha = "828779";
                            //client.DownloadData("http://ipv4.google.com/sorry/CaptchaRedirect?id=" + id + "&captcha=" + captcha + "&continue=" + url);
                            //var response = client.ResponseHeaders;
                        }
                    }
                }
            }

            return html;
        }

        // lower level implementation
        public static void GetSiteText_4()
        {
            string requestData = string.Empty; // ?
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://www.yoursite.com/resource/file.htm");

            using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream(), Encoding.UTF8))
            {
                streamWriter.Write(requestData);
            }

            string responseData = string.Empty;
            HttpWebResponse httpResponse = (HttpWebResponse)webRequest.GetResponse();
            using (StreamReader responseReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseData = responseReader.ReadToEnd();
            }
        }

        // this method should work correctly with BOM
        public static string ReadTextFromUrl(string url)
        {
            // WebClient is still convenient
            // Assume UTF8, but detect BOM - could also honor response charset I suppose
            using (var client = new WebClient())
            using (var stream = client.OpenRead(url))
            using (var textReader = new StreamReader(stream, Encoding.UTF8, true))
            {
                return textReader.ReadToEnd();
            }
        }

        public static string GetInnerTextFromPage(string url)
        {
            var document = new XmlDocument();
            document.Load(url);
            string allText = document.InnerText;
            return allText;
        }
    }
}
