using System;
using System.ComponentModel.DataAnnotations;

namespace Musaca.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        [Range(0.01,(double)decimal.MaxValue)]
        public decimal Price { get; set; }
    }
}
