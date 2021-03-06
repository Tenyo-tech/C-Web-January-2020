﻿using System.Collections.Generic;
using Panda.Data.Models;

namespace Panda.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password);

        User GetUserOrNull(string username, string password);

        IEnumerable<string> GetUserNames();
    }
}
