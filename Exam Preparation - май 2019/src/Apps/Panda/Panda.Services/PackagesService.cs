using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Panda.Data;
using Panda.Data.Models;

namespace Panda.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly PandaDbContext db;

        public PackagesService(PandaDbContext db)
        {
            this.db = db;
        }
        public void Create(string description, decimal weight, string shippingAddress, string recipientName)
        {
            var userId = this.db.Users.Where(x => x.Username == recipientName).Select(x=>x.Id).FirstOrDefault();
            if (userId == null)
            {
                return;
            }

            var package = new Package
            {
                Description = description,
                Weight = weight,
                Status = PackageStatus.Pending,
                ShippingAddress = shippingAddress,
                RecipientId = userId,
            };
            this.db.Packages.Add(package);
            this.db.SaveChanges();
        }

        public IQueryable<Package> GetAllByStatus(PackageStatus status)
        {
            var packages = this.db.Packages.Where(x => x.Status == status);
            return packages;
        }
    }
}
