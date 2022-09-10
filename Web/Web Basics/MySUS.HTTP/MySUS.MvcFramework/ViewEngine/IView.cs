namespace MySUS.MvcFramework.ViewEngine
{
    public interface IView
    {
        string Execute(object viewModel, string user);
    }
}
