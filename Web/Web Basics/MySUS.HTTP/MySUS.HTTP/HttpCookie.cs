namespace MySUS.HTTP
{
    public class HttpCookie
    {
        public HttpCookie(string line)
        {
            this.Parse(line);
        }

        public HttpCookie(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }


        public override string ToString()
        {
            return $"{this.Name}={this.Value}";
        }

        private void Parse(string line)
        {
            var cookieArgs = line.Split(new string[] { "=" }, 2, System.StringSplitOptions.None);

            this.Name = cookieArgs[0];
            this.Value = cookieArgs[1];
        }
    }
}
