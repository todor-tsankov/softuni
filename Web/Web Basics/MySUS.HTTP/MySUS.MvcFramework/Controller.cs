using System.IO;
using System.Text;
using System.Runtime.CompilerServices;

using MySUS.HTTP;
using MySUS.MvcFramework.ViewEngine;

namespace MySUS.MvcFramework
{
    public abstract class Controller
    {
        private const string ViewFolder = "Views";
        private const string ViewType = ".html";
        private const string MainBody = "@MainBody";
        private const string ControllerSufix = "Controller";

        private const string HtmlContenType = "text/html";
        private const string UserIdSessionName = "UserId";
        private IViewEngine viewEngine;

        public Controller()
        {
            this.viewEngine = new MySusViewEngine();
        }

        public HttpRequest httpRequest { get; set; }
        
        protected HttpResponse View(object viewModel = null, [CallerMemberName] string actionName = null)
        {
            var viewEngine = new MySusViewEngine();

            var layout = File.ReadAllText($"{ViewFolder}/Shared/_Layout.html");

            var mainPath = $"{ViewFolder}/" +
                           $"{this.GetType().Name.Replace(ControllerSufix, string.Empty)}/" +
                           $"{actionName}" +
                           ViewType;

            var mainText = File.ReadAllText(mainPath);
            var template = layout.Replace(MainBody, mainText);

            var result = viewEngine.GenerateHtml(template, viewModel, this.GetUserId());
            var bytes = Encoding.UTF8.GetBytes(result);

            return new HttpResponse(HtmlContenType, bytes);
        }

        protected HttpResponse Redirect(string url)
        {
            var response = new HttpResponse(HttpStatusCode.Found);

            var locationHeader = new HttpHeader("Location", url);
            response.Headers.Add("Location", locationHeader);

            return response;
        }

        protected void SignIn(string userId)
        {
            this.httpRequest.Session[UserIdSessionName] = userId;
        }

        protected void SignOut()
        {
            this.httpRequest.Session[UserIdSessionName] = null;
        }

        protected bool IsSignedIn()
        {
            return this.httpRequest.Session.ContainsKey(UserIdSessionName) 
                && this.httpRequest.Session[UserIdSessionName] != null;
        }

        protected string GetUserId()
        {
            if (!this.IsSignedIn())
            {
                return null;
            }

            return this.httpRequest.Session[UserIdSessionName];
        }
    }
}
