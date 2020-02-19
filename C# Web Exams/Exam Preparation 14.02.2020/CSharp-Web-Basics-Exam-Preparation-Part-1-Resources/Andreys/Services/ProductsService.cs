namespace Andreys.Services
{
    using Andreys.Data;
    using Andreys.Models;
    using Andreys.ViewModels.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public int Add(AddProductModel model)
        {
            var enumCategory = Enum.Parse<Category>(model.Category);
            var enumGender = Enum.Parse<Gender>(model.Gender);
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Gender = enumGender,
                Category = enumCategory,
                
            };
            this.db.Products.Add(product);
            this.db.SaveChanges();

            return product.Id;
        }

        public IEnumerable<Product> GetAll()
        {
           return this.db.Products
                .Select(x=> new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,

                })
                .ToArray();
        }
    }
}