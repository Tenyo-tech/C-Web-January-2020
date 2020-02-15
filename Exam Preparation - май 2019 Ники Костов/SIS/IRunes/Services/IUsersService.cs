using System;

namespace IRunes.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void Register(string username, string email, string password);

        bool UsernameExist(string username);

        bool EmailExist(string email);

        string GetUsername(string id);
    }
}
