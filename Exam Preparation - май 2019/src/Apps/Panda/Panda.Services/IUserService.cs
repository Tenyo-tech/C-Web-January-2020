using System.Collections.Generic;
using Panda.Data.Models;

namespace Panda.Services
{
    public interface IUserService
    {
        string CreateUser(string username, string email, string password);

        User GetUsersOrNull(string username, string password);

        IEnumerable<string> GetUserNames();
    }
}
