using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IRunes.Models
{
    public class User 
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        
    }
}
