using Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ViewEngine;

namespace SimpleRouteLogger
{
    public class Enigne
    {
        public const string NewLine = "\r\n";

        public const int DefaultPort = 80;
        public const int BufferSize = 1000000;

        public void Run()
        {
            var db = new RouteLogDbContext();
            var created = db.Database.EnsureCreated();

            if (created)
            {
                var seeder = new Seeder();

                seeder.Seed(db);
            }

            var tcpListener = new TcpListener(IPAddress.Loopback, DefaultPort);
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using var stream = client.GetStream();

                var buffer = new byte[BufferSize];
                var actualLength = stream.Read(buffer, 0, BufferSize);

                var homePage = new HomePage(db.Routes.ToList());
                var html = homePage.GenerateHTML();

                var response = "HTTP/1.1 200 OK" + NewLine +
                        "Server: ToshkoServer 2020" + NewLine +
                        "Content-Type: text/html; charset=utf-8" + NewLine +
                        "Content-Lenght: " + html.Length + NewLine +
                        NewLine +
                        html + NewLine;

                var responseBytes = Encoding.UTF8.GetBytes(response);

                stream.Write(responseBytes);
            }
        }
    }
}
