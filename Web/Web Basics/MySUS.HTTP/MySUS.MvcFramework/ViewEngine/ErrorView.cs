using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace MySUS.MvcFramework.ViewEngine
{
    public class ErrorView : IView
    {
        private string code;
        private IEnumerable<string> errorMessages;

        public ErrorView(IEnumerable<string> errorMessages, string code)
        {
            this.code = code;
            this.errorMessages = errorMessages;
        }

        public string Execute(object viewModel, string user = null)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<html>");
            sb.AppendLine($"<h1>View compile found: {errorMessages.Count()} errors!</h1>");
            sb.AppendLine($"<ul>");

            foreach (var msg in errorMessages)
            {
                sb.AppendLine($"<li>{msg}</li>");
            }

            sb.AppendLine($"</ul>");
            sb.AppendLine($"<p>{code}</p>");

            return sb.ToString();
        }
    }
}
