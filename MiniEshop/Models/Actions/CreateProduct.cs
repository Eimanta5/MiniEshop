using System.ComponentModel.DataAnnotations;

namespace MiniEshop.Models.Actions
{
    public class CreateProduct
    {
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
    }
}
