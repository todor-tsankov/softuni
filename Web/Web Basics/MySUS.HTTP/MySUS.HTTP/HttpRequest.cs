using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Net;

namespace MySUS.HTTP
{
    public class HttpRequest
    {
        public static IDictionary<string, IDictionary<string, string>> Sessions = new Dictionary<string, IDictionary<string, string>>();

        public HttpRequest(string requestString)
        {
            this.Headers = new Dictionary<string, HttpHeader>();
            this.Cookies = new Dictionary<string, HttpCookie>();

            this.Session = new Dictionary<string, string>();
            this.FormData = new Dictionary<string, string>();
            this.QueryData = new Dictionary<string, string>();

            this.Parse(requestString);
        }

        public string Path { get; set; }
        public string QueryString { get; set; }
        public string Body { get; set; }
        public HttpMethod Method { get; set; }

        public IDictionary<string, HttpHeader> Headers { get; set; }
        public IDictionary<string, HttpCookie> Cookies { get; set; }
        public IDictionary<string, string> Session { get; set; }
        public IDictionary<string, string> FormData { get; set; }
        public IDictionary<string, string> QueryData { get; set; }

        private void Parse(string requestString)
        {
            var lines = requestString.Split(new string[] { HttpConstants.NewLine }, StringSplitOptions.None);

            this.ProcessHeading(lines);
            this.ProcessHeadersAndBody(lines);
            this.ProcessCookies();
            this.ManageSession();
            this.ProcessData(this.FormData, this.Body);
            this.ProcessData(this.QueryData, this.QueryString);
        }

        private void ProcessHeading(string[] lines)
        {
            var headerArgs = lines[0].Split(new string[] { " " }, StringSplitOptions.None);

            this.Method = (HttpMethod)Enum.Parse(typeof(HttpMethod), headerArgs[0]);

            var pathAndQuery = headerArgs[1].Split(new char[] { '?' }, 2);
            this.Path = pathAndQuery[0].ToLowerInvariant();

            if (pathAndQuery.Length > 1)
            {
                this.QueryString = pathAndQuery[1];
            }
        }

        private void ProcessHeadersAndBody(string[] lines)
        {
            var isBody = false;
            var bodyBuilder = new StringBuilder();

            for (int i = 1; i < lines.Length; i++)
            {
                var currentLine = lines[i];

                if (string.IsNullOrWhiteSpace(currentLine))
                {
                    isBody = true;

                    continue;
                }

                if (!isBody)
                {
                    var header = new HttpHeader(currentLine);
                    this.Headers[header.Name] = header;
                }
                else
                {
                    bodyBuilder.AppendLine(lines[i]);
                }
            }

            this.Body = bodyBuilder.ToString().TrimEnd('\r', '\n');
        }

        private void ProcessCookies()
        {
            if (this.Headers.ContainsKey(HttpConstants.RequestCookieHeader))
            {
                var cookiesString = this.Headers[HttpConstants.RequestCookieHeader].Value;
                var cookies = cookiesString.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var cookieString in cookies)
                {
                    var cookie = new HttpCookie(cookieString);

                    this.Cookies[cookie.Name] = cookie;
                }
            }
        }

        private void ManageSession()
        {
            var sessionCookie = this.Cookies.FirstOrDefault(x => x.Key == HttpConstants.SessionCookieName).Value;

            if (sessionCookie == null)
            {
                var sessionId = Guid.NewGuid().ToString();
                var cookie = new HttpCookie(HttpConstants.SessionCookieName, sessionId);

                Sessions[sessionId] = this.Session;
                this.Cookies[HttpConstants.SessionCookieName] = new HttpCookie(HttpConstants.SessionCookieName, sessionId);
            }
            else if (!Sessions.ContainsKey(sessionCookie.Value))
            {
                Sessions.Add(sessionCookie.Value, this.Session);
            }
            else
            {
                this.Session = Sessions[sessionCookie.Value];
            }
        }

        private void ProcessData(IDictionary<string, string> dictionary, string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return;
            }

            var data = line.Split('&');

            foreach (var item in data)
            {
                var itemData = item.Split(new char[] { '=' }, 2);

                var key = WebUtility.UrlDecode(itemData[0]);
                var value = WebUtility.UrlDecode(itemData[1]);

                dictionary[key] = value;
            }
        }
    }
}
