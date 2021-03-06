﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MiniEshop.Database.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2560)]
        public string Description { get; set; }

        [Required]
        public DateTime Created { get; set; }
        
        [Required]
        public DateTime Updated { get; set; }
    }
}
