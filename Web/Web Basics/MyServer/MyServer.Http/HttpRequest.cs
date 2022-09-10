using System;
using System.Linq;
using System.Collections.Generic;

namespace MyServer.Http
{
    public class HttpRequest
    {
        public const string NewLine = "\r\n";

        public HttpRequest()
        {
            this.Headers = new List<HttpHeader>();
        }

        public string HttpVersion { get; set; }
        public Method Method { get; set; }

        public List<HttpHeader> Headers { get; set; }

        public List<HttpCookie> Cookies { get; set; }

        public static HttpRequest Parse(string content)
        {
            try
            {
                return Process(content);
            }
            catch
            {
                throw;
            }
        }

        private static HttpRequest Process(string content)
        {
            var request = new HttpRequest();

            var lines = content.Split(NewLine, System.StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

            request.Method = Method.Parse<Method>(first[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                try
                {
                    var currentLineArgs = lines[i].Split(": ");

                    var headerName = currentLineArgs[0];
                    var headerValue = currentLineArgs[1];

                    if (headerName.ToLower() == "cookie")
                    {
                        var cookies = headerValue
                            .Split("; ")
                            .Select(x => new HttpCookie
                            {
                                Value = x
                            })
                            .ToList();

                        request.Cookies = cookies;
                    }
                    else
                    {
                        var header = new HttpHeader()
                        {
                            Name = headerName,
                            Value = headerValue
                        };

                        request.Headers.Add(header);
                    }

                }
                catch (IndexOutOfRangeException)
                {
                }
            }

            return request;
        }
    }
}
