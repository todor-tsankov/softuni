using System;

namespace MySUS.HTTP
{
    public abstract class HttpMethodAttribute : Attribute
    {
        public HttpMethodAttribute(string path)
        {
            this.Path = path?.ToLowerInvariant();
        }

        public string Path { get; set; }
    }
}
