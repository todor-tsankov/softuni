namespace MyServer.Http
{
    public class HttpCookie
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Name ?? string.Empty}: {Value}";
        }
    }
}
