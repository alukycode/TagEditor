namespace Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Web;
    using System.Windows.Forms;

    public static class GoogleHelper
    {
        private static CookieContainer _cookieJar = new CookieContainer();
        private static Dictionary<string, List<string>> _cachedUrls = new Dictionary<string, List<string>>();
        private static WebBrowser _browser = new WebBrowser();
        private static bool completed = false;

        public static List<string> GetSearchUrls(string searchQuery)
        {
            const string googleSearchUrl = "https://www.google.com/search?q=";
            const string googleLinksRegexPattern = @"data-href=""([^""]+)";
            const string googleLinksRegexPattern2 = @"<h3[^>]+><a href=""([^""]+)";
            const string googleLinksRegexPatternAdditional = @"/url\?q=([^&]+)";
            List<string> cachedResult;
            _cachedUrls.TryGetValue(searchQuery, out cachedResult);
            if (cachedResult != null)
            {
                return cachedResult;
            }

            var searchUrl = googleSearchUrl + HttpUtility.UrlEncode(searchQuery);
            var html = GetHtmlWithCaptchaCheck(searchUrl);

            var matches = Regex.Matches(html, googleLinksRegexPattern); // extract urls from page
            if (matches.Count == 0)
                matches = Regex.Matches(html, googleLinksRegexPattern2);

            var urls = new List<string>();
            foreach (Match match in matches)
            {
                var url = match.Groups[1].Value;
                var additionalMatch = Regex.Match(url, googleLinksRegexPatternAdditional);
                if (additionalMatch.Success)
                    url = additionalMatch.Groups[1].Value;
                urls.Add(url);
            }

            _cachedUrls.Add(searchQuery, urls);

            return urls;
        }

        [STAThread]
        public static List<string> GetImagesUrls(string searchQuery)
        {
            List<string> cachedResult;
            _cachedUrls.TryGetValue(searchQuery, out cachedResult);
            if (cachedResult != null)
            {
                return cachedResult;
            }

            const string googleImagesSearchUrl = "https://www.google.com/search?tbm=isch&q=";

            var searchUrl = googleImagesSearchUrl + HttpUtility.UrlEncode(searchQuery);

            //var html = GetHtmlWithCaptchaCheck(searchUrl);

            _browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(BrowserDocumentCompletedHandler);
            _browser.ScriptErrorsSuppressed = true;
            completed = false;
            _browser.Navigate(searchUrl);
            while (! completed)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }
            var html = _browser.Document.Body.InnerHtml;

            const string linksRegexPattern = @"imgurl=([^&]+)";

            var matches = Regex.Matches(html, linksRegexPattern); // extract urls from page
            if (matches.Count == 0)
            {
                throw new Exception("needed workaround");
                html = GetRedirectHtml(html);
                matches = Regex.Matches(html, linksRegexPattern); // extract urls from page
                if (matches.Count == 0)
                    throw new Exception("needed workaround");
            }


            var urls = new List<string>();
            foreach (Match match in matches)
            {
                var url = match.Groups[1].Value;
                urls.Add(url);
            }

            _cachedUrls.Add(searchQuery, urls);

            return urls;
        }

        private static void BrowserDocumentCompletedHandler(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            completed = true;
        }

        private static string GetRedirectHtml(string html)
        {
            var redirectUrl = "https://www.google.com" + Regex.Match(html, @"<a href=""([^""]+)").Groups[1].Value;
            html = GetHtmlWithCaptchaCheck(redirectUrl);

            return html;
        }

        private static string GetHtmlWithCaptchaCheck(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = _cookieJar;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
            request.AllowAutoRedirect = true;

            try
            {
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                return ProcessCaptchaResponse503(e.Response, url);
            }
        }

        private static string ProcessCaptchaResponse503(WebResponse response, string continueUrl)
        {
            var stream = response.GetResponseStream();
            using (var reader = new StreamReader(stream))
            {
                var html = reader.ReadToEnd();

                var captchaUrl = "https://ipv4.google.com" + Regex.Match(html, @"<img src=""([^""]+)").Groups[1].Value;
                var captchaId = Regex.Match(captchaUrl, @"id=(\d+)").Groups[1].Value;

                var captchaImage = GetImageUsingCookies(captchaUrl);
                var captchaText = ShowCaptchaDialog(captchaImage);
                return CheckCaptcha(captchaId, captchaText, continueUrl);
            }
        }

        private static Image GetImageUsingCookies(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = _cookieJar;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                return Image.FromStream(stream);
            }
        }

        private static string GetHtmlUsingCookies(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = _cookieJar;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public static void DisableRedirecting()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://www.google.com/ncr");
            request.CookieContainer = _cookieJar;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                reader.ReadToEnd();
            }
            
        }

        private static string CheckCaptcha(string captchaId, string captchaText, string continueUrl)
        {
            // https://ipv4.google.com/sorry/CaptchaRedirect?id=5530563399652690512&captcha=12465822&submit=submit&continue=https://www.google.com/search?q=enter%20shikari
            var url = "https://ipv4.google.com/sorry/CaptchaRedirect?id="
                + captchaId + "&captcha=" + captchaText + "&submit=submit&continue=" + continueUrl;

            return GetHtmlUsingCookies(url);
        }

        private static string ShowCaptchaDialog(Image captchaImage)
        {
            var form = new Form
            {
                ClientSize = new Size(220, 160),
                StartPosition = FormStartPosition.CenterScreen
            };

            var pictureBox = new PictureBox
            {
                Left = 10,
                Top = 10,
                SizeMode = PictureBoxSizeMode.AutoSize, // google captcha size 200x70
                Image = captchaImage
            };

            var textBox = new TextBox
            {
                Left = 10,
                Top = 90
            };

            var button = new Button
            {
                Left = 10,
                Top = 120,
                AutoSize = true,
                Text = "Okay, Google",
            };

            button.Click += new EventHandler(CaptchaButtonHandler);

            form.Controls.Add(pictureBox);
            form.Controls.Add(textBox);
            form.Controls.Add(button);

            form.ShowDialog();

            return textBox.Text;
        }

        private static void CaptchaButtonHandler(object sender, EventArgs e)
        {
            var button = sender as Button;
            var form = button.Parent as Form;
            form.Close();
        }
    }
}

//const string yandexSearchUrl = "https://yandex.by/search/?text=";
//const string nigmaSearchUrl = "http://nigma.ru/?s="; // антибан для нигмы - ввести капчу, получить куку spam_captcha
//const string nigmaLinksRegexPattern = @"snippet_title.*?href=""([^""]+)";
