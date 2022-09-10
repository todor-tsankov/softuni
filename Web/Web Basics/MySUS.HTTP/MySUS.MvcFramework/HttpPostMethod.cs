namespace MySUS.HTTP
{
    public class HttpPostMethod : HttpMethodAttribute
    {
        public HttpPostMethod(string path = null)
            :base(path)
        {
        }
    }
}
