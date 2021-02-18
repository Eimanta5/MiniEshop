using System;
using System.ComponentModel.DataAnnotations;

namespace MiniEshop.Database.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public User User { get; set; }
    }
}
