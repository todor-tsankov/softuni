using Models;
using System.Collections.Generic;
using System.Text;

namespace ViewEngine
{
    public class HomePage
    {
        public List<Route> Routes { get; set; }

        public HomePage(List<Route> routes)
        {
            this.Routes = routes;
        }

        public string GenerateHTML()
        {
            var sb = new StringBuilder();

            //sb.AppendLine("<!DOCTYPE html><html lang=\"en\"><head><meta charset=\"utf-8\" /><title></title></head><body>");
            sb.AppendLine("<h1>Toshko's 8a</h1>");
            
            sb.AppendLine("<h2>Routes in db:</h2>");
            sb.AppendLine("<ul>");

            foreach (var r in this.Routes)
            {
                sb.AppendLine($"<li>{r.Name} =>  {r.Grade}</li>");
            }

            sb.AppendLine("</ul>");

            sb.AppendLine("<h2>Add Route: </h2>");
            sb.AppendLine("<p>Name-------------Grade</p>");
            sb.AppendLine("<form action=/addRoute method=post><input name=route /><input name=grade/>");
            sb.AppendLine("<input type=submit /></form>");
            sb.AppendLine("</body></html>");

            return sb.ToString().TrimEnd();
        }
    }
}
