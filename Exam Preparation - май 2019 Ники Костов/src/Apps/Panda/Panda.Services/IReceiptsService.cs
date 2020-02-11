using System.Linq;
using Panda.Data.Models;

namespace Panda.Services
{
    public interface IReceiptsService
    {
        void CreateFromPackage(decimal weight, string packageId, string recipientId);

        IQueryable<Receipt> GetAll();
    }
}
