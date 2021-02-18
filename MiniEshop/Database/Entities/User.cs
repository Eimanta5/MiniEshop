using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniEshop.Database.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
   
        [Required]
        public DateTime Created { get; set; }

        [Required]
        [MaxLength(12)]
        [Column(TypeName = "varchar(12)")]
        public string PhoneNumber { get; set; }

        [Required]
        public bool IsAdministration { get; set; }

        ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
