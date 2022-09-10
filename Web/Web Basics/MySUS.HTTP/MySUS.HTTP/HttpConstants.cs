using System.ComponentModel.Design.Serialization;

namespace MySUS.HTTP
{
    public static class HttpConstants
    {
        public const int BufferSize = 4096;
        public const string NewLine = "\r\n";
        public const string HttpVersion = "HTTP/1.1";
        public const string RequestCookieHeader = "Cookie";
        public const string SessionCookieName = "MySUS_SID";
    }
}
