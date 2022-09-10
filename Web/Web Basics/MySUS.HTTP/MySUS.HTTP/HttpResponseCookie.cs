using System.Text;

namespace MySUS.HTTP
{
    public class HttpResponseCookie : HttpCookie
    {
        public HttpResponseCookie(string name, string value) 
            : base(name, value)
        {
            this.Path = "/";
        }

        public string Path { get; set; }
        public int MaxAge { get; set; }
        public bool HttpOnly { get; set; }

        public override string ToString()
        {
            var cookieBuilder = new StringBuilder();

            cookieBuilder.Append($"{this.Name}={this.Value}; Path={this.Path};");

            if (MaxAge != 0)
            {
                cookieBuilder.Append($" Max-Age={this.MaxAge};");
            }

            if (this.HttpOnly)
            {
                cookieBuilder.Append(" HttpOnly;");
            }

            return cookieBuilder.ToString();
        }
    }
}
