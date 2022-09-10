namespace Git.Services
{
    public interface IUsersService
    {
        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);

        string GetUserId(string username, string password);

        string CreateUser(string username, string email, string password);
    }
}
