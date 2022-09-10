namespace MySUS.HTTP
{
    public enum HttpStatusCode
    {
        Continue = 100,
        SwitchingProtocol = 101,

        Ok = 200,
        Created = 201,

        MovedPermanently = 301,
        Found = 302,

        BadRequest = 400,
        NotFound = 404
    }
}
