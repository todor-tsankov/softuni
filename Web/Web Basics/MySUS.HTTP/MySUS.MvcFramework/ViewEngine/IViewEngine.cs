namespace MySUS.MvcFramework.ViewEngine
{
    public interface IViewEngine
    {
        string GenerateHtml(string cshtml, object viewModel, string user);
    }
}
