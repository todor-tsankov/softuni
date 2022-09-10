using System;
using System.Text;
using System.Collections.Generic;

namespace MySUS.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(HttpStatusCode statusCode)
        {
            this.Body = new byte[0];
            this.StatusCode = statusCode;

            this.Headers = new Dictionary<string, HttpHeader>();
            this.Cookies = new Dictionary<string, HttpCookie>();
        }

        public HttpResponse(string contentType, byte[] body, HttpStatusCode httpStatusCode = HttpStatusCode.Ok)
        {
            this.NullCheck(contentType, body);

            this.StatusCode = httpStatusCode;
            this.Headers = new Dictionary<string, HttpHeader>();
            this.Cookies = new Dictionary<string, HttpCookie>();

            this.Body = body;

            this.Headers["Content-Type"] = new HttpHeader("Content-Type", contentType);
            this.Headers["Content-Length"] = new HttpHeader("Content-Length", this.Body.Length.ToString());
        }

        public byte[] Body { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public IDictionary<string, HttpHeader> Headers { get; set; }
        public IDictionary<string, HttpCookie> Cookies { get; set; }

        public override string ToString()
        {
            var responseBuilder = new StringBuilder();

            responseBuilder.Append($"{HttpConstants.HttpVersion} {(int)this.StatusCode} {this.StatusCode.ToString()}");
            responseBuilder.Append(HttpConstants.NewLine);

            foreach (var header in this.Headers)
            {
                responseBuilder.Append(header.Value.ToString());
                responseBuilder.Append(HttpConstants.NewLine);
            }

            foreach (var cookie in this.Cookies)
            {
                responseBuilder.Append($"Set-Cookie: {cookie.Value.ToString()}");
                responseBuilder.Append(HttpConstants.NewLine);
            }

            responseBuilder.Append(HttpConstants.NewLine);

            return responseBuilder.ToString();
        }

        private void NullCheck(string contentType, byte[] body)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            if (contentType == null)
            {
                throw new ArgumentNullException(nameof(contentType));
            }
        }
    }
}
