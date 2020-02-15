using System.Linq;
using System.Security.Cryptography;
using System.Text;
using IRunes.Models;

namespace IRunes.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string GetUserId(string username, string password)
        {
            var hashedPassowrd = this.Hash(password);
            var user = this.db.Users.FirstOrDefault(x => x.Username == username && x.Password == hashedPassowrd);
            if (user == null)
            {
                return null;
            }

            return user.Id;
        }

        public void Register(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password)

            };
            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public bool UsernameExist(string username)
        {
            
            return this.db.Users.Any(x => x.Username == username);
        }

        public bool EmailExist(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public string GetUsername(string id)
        {
            var username = this.db.Users
                .Where(x => x.Id == id)
                .Select(x => x.Username)
                .FirstOrDefault();
            return username;
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
