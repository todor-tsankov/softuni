using System.Threading.Tasks;

namespace MyServer.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var server = new Server();

            await server.Run();
        }
    }
}
