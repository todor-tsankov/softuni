using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MySUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        private ICollection<Route> routeTable;

        public HttpServer(ICollection<Route> routeTable)
        {
            this.routeTable = routeTable;
        }

        public async Task StartAsync(int port)
        {
            var tcpListener = new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();

            Console.WriteLine($"Started server at {IPAddress.Loopback}:{port}");
            Console.WriteLine($"Waiting for client...");
            Console.WriteLine();

            while (true)
            {
                var client = await tcpListener.AcceptTcpClientAsync();

                try
                {
                    ProcessClient(client);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private async Task ProcessClient(TcpClient client)
        {
            var stream = client.GetStream();
            var requestBytes = await ReadStreamBytesAsync(stream);

            if (!requestBytes.Any())
            {
                return;
            }

            var requestString = Encoding.UTF8.GetString(requestBytes);

            Console.WriteLine("HTTP Request:");
            Console.WriteLine(requestString.TrimEnd());
            Console.WriteLine();

            var httpRequest = new HttpRequest(requestString);

            var path = httpRequest.Path;
            var method = httpRequest.Method;

            HttpResponse httpResponse;

            if (this.routeTable.Any(x => x.Path == path && x.Method == method))
            {
                var route = this.routeTable.First(x => x.Path == path && x.Method == method);

                httpResponse = route.Action(httpRequest);
            }
            else
            {
                var notFoundHtml = "<h1>Not found :(</h1>";
                var bytes = Encoding.UTF8.GetBytes(notFoundHtml);

                httpResponse = new HttpResponse("text/html", bytes, HttpStatusCode.NotFound);
            }

            var sessionCookie = httpRequest.Cookies[HttpConstants.SessionCookieName];
            var sessionResponseCookie = new HttpResponseCookie(HttpConstants.SessionCookieName, sessionCookie.Value);

            httpResponse.Cookies.Add(HttpConstants.SessionCookieName, sessionResponseCookie);

            var serverHeader = new HttpHeader("Server", "Toshko Server 1.1");
            httpResponse.Headers.Add(serverHeader.Name, serverHeader);

            var responseHeaderString = httpResponse.ToString();
            var responseHeaderBytes = Encoding.UTF8.GetBytes(responseHeaderString);

            Console.WriteLine("HTTP Response:");
            Console.WriteLine(responseHeaderString.TrimEnd());
            Console.WriteLine("-----------------------------------------------------------");

            var responseBody = httpResponse.Body;

            await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
            await stream.WriteAsync(responseBody, 0, responseBody.Length);

            client.Close();
        }

        private async Task<byte[]> ReadStreamBytesAsync(NetworkStream stream)
        {
            var requestBytes = new List<byte>();
            var buffer = new byte[HttpConstants.BufferSize];
            var offset = 0;

            while (true)
            {
                var countBytesRead = await stream.ReadAsync(buffer, offset, HttpConstants.BufferSize);

                if (countBytesRead < HttpConstants.BufferSize)
                {
                    var partialBuffer = new byte[countBytesRead];
                    Array.Copy(buffer, partialBuffer, countBytesRead);

                    requestBytes.AddRange(partialBuffer);
                    break;
                }
                else
                {
                    requestBytes.AddRange(buffer);
                }

                offset += countBytesRead;
            }

            return requestBytes.ToArray();
        }
    }
}
