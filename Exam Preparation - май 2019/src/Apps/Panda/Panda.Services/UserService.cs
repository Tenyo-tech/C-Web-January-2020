using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore.Internal;
using Panda.Data;
using Panda.Data.Models;

namespace Panda.Services
{
    public class UserService : IUserService
    {
        private readonly PandaDbContext db;

        public UserService(PandaDbContext db)
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

        public User GetUsersOrNull(string username, string password)
        {
            var passwordHash = this.HashPassword(password);
            var user = this.db.Users.FirstOrDefault(x => x.Username == username && x.Password == passwordHash);
            return user;
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