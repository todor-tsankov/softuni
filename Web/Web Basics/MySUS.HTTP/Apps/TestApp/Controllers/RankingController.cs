using MySUS.HTTP;
using MySUS.MvcFramework;

namespace TestApp.Controllers
{
    public class RankingController : Controller
    {
        [HttpGetMethod]
        public HttpResponse Global()
        {
            return this.View();
        }
    }
}
