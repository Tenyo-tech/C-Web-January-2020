using System.Collections.Generic;
using System.Linq;
using Panda.Data.Models;

namespace Panda.Services
{
    public interface IPackagesService
    {
        void Create(string description, decimal weight, string shippingAddress, string recipientName);

        IQueryable<Package> GetAllByStatus(PackageStatus status);
    }

}
