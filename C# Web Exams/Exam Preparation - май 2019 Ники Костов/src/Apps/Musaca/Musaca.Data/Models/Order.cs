using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musaca.Data.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<Product>();
        }

        public string Id { get; set; }

        public Status Status { get; set; }

        public DateTime IssuedOn { get; set; }

        public ICollection<Product> Products { get; set; }

        [Required]
        public string CashierId { get; set; }

        public User Cashier { get; set; }
    }
}
