using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Panda.Data;
using Panda.Data.Models;

namespace Panda.Services
{
    public class UsersService : IUsersService
    {
        private readonly PandaDbContext db;

        public UsersService(PandaDbContext db)
        {
            this.db = db;
        }
        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password),
            };
            this.db.Users.Add(user);
            this.db.SaveChanges();
            return user.Id;
        }

        public User GetUserOrNull(string username, string password)
        {
            var hashedPassword = this.HashPassword(password);

            var user = this.db.Users.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);
            return user;
        }

        public IEnumerable<string> GetUserNames()
        {
             var userNames = this.db.Users.Select(x => x.Username).ToList();
             return userNames;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}