namespace Panda.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password);
    }
}
