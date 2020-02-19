using System.Collections.Generic;
using Andreys.Models;
using Andreys.ViewModels.Products;

namespace Andreys.Services
{
    public interface IProductsService
    {
        int Add(AddProductModel model);

        IEnumerable<Product> GetAll();
    }
}
