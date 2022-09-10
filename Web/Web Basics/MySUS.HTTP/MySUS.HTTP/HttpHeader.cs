using System;

namespace MySUS.HTTP
{
    public class HttpHeader
    {
        public HttpHeader(string line)
        {
            this.Parse(line);
        }


        public HttpHeader(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }


        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }

        private void Parse(string line)
        {
            var lineArgs = line.Split(new string[] { ": " }, 2, StringSplitOptions.None);

            this.Name = lineArgs[0];
            this.Value = lineArgs[1];
        }
    }
}
