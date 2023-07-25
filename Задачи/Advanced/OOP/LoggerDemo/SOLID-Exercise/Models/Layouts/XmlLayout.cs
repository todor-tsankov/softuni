using System.Text;

using SOLID_Exercise.Models.Contracts;

namespace SOLID_Exercise.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            var sb = new StringBuilder();

            sb.AppendLine("<log>")
              .AppendLine("<date>{0}</date>")
              .AppendLine("<level>{1}</level>")
              .AppendLine("<message>{2}</message>")
              .AppendLine("</log>");

            return sb.ToString()
                     .TrimEnd();
        }
    }
}
