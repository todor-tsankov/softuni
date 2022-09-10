using System.Text;
using System.Collections.Generic;

namespace MyServer.Http
{
    public class HttpResponse
    {
        private const string NewLine = "\r\n";
        public string HttpVersion { get; set; }

        public StatusCode StatusCode { get; set; }

        public List<HttpHeader> Headers { get; set; }

        public List<HttpCookie> Cookies { get; set; }

        public string Body { get; set; }

        public static string GetString(HttpResponse response)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{response.HttpVersion} {(int)response.StatusCode} {response.StatusCode}");

            foreach (var h in response.Headers)
            {
                sb.AppendLine($"{h.Name}: {h.Value}");
            }

            foreach (var h in response.Cookies)
            {
                sb.AppendLine($"{h.Name}: {h.Value}");
            }

            sb.Append(NewLine);
            sb.AppendLine(response.Body);

            return sb.ToString();
        }
    }
}
