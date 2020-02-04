using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Panda.Data.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [MinLength(5), MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [MinLength(5), MaxLength(20)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Package> Packages { get; set; } = new HashSet<Package>();

        public virtual ICollection<Receipt> Receipts { get; set; } = new HashSet<Receipt>();
    }
}
