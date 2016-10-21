using System.Drawing;

namespace Shared
{
    public class GoogleRequestInfo
    {
        public bool Success { get; set; }
        public string Html { get; set; }
        public string ResponseUri { get; set; }
        public string CaptchaUrl { get; set; }
        public Image CaptchaImage { get; set; }
    }
}
