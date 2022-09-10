using MyServer.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServer.Web
{
    public class HttpHandler 
    {
        public async Task<byte[]> Proccess(byte[] requestBytes)
        {
            var requestString = Encoding.UTF8.GetString(requestBytes);
            var request = HttpRequest.Parse(requestString);

            var hostStr = request.Headers.First(x => x.Name == "Host");

            var response = new HttpResponse();

            var responseString = HttpResponse.GetString(response);
            var responseBytes = Encoding.UTF8.GetBytes(responseString);

            return responseBytes;
        }
    }
}
