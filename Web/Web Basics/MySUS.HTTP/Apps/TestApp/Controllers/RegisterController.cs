using MySUS.HTTP;
using MySUS.MvcFramework;

namespace TestApp.Controllers
{
    public class RegisterController : Controller
    {
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPostMethod]
        public HttpResponse Register(string email, string password, string confirmPassword)
        {
            return this.Redirect("/Login/Login");
        }
    }
}
