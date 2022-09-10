using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace MyServer.Web
{
    public class Server
    {
        private const int MaxRequestSize = 4096;

        private const int Port = 80;
        private const string LocalIp = "127.0.0.1";

        private TcpListener listener;

        public Server()
        {
            var bytes = Encoding.UTF8.GetBytes(LocalIp);
            var ipAddress = new IPAddress(bytes);

            listener = new TcpListener(ipAddress, Port);
        }

        public async Task Run()
        {
            this.listener.Start();

            Console.WriteLine($"Server started running at {LocalIp}:{Port}");

            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();
                var stream = client.GetStream();

                var requestBytes = new byte[MaxRequestSize];
                var count = stream.Read(requestBytes, 0, MaxRequestSize);

                if (count == 0)
                {
                    continue;
                }


            }
        }
    }
}
