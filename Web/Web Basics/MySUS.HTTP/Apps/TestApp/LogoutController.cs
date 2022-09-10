using MySUS.HTTP;
using MySUS.MvcFramework;

namespace TestApp
{
    public class LogoutController : Controller
    {
        public HttpResponse Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }
    }
}
