using System.Threading.Tasks;

namespace MySUS.HTTP
{
    public interface IHttpServer
    {
        Task StartAsync(int port);
    }
}
