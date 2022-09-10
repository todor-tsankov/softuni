using MySUS.HTTP;
using MySUS.MvcFramework;
using System.Collections.Generic;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGetMethod("/")]
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
