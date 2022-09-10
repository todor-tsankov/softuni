using MySUS.HTTP;
using MySUS.MvcFramework;

namespace TestApp.Controllers
{
    public class AscentsController : Controller
    {
        public HttpResponse All()
        {
            return this.View();
        }
    }
}
