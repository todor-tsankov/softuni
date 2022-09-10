using MySUS.HTTP;
using MySUS.MvcFramework;

namespace TestApp.Controllers
{
    public class LoginController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPostMethod]
        public HttpResponse Login(TestUser user)
        {
            if (user.Email == "Toshko@abv.bg" && user.Password == "1234")
            {
                this.SignIn("1");
            }

            return this.Redirect("/");
        }
    }
}
