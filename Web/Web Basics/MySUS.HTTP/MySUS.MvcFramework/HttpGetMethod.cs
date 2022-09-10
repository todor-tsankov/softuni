namespace MySUS.HTTP
{
    public class HttpGetMethod : HttpMethodAttribute
    {
        public HttpGetMethod(string path = null)
            :base(path)
        {
        }
    }
}
