using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniEshop.Database.Entities
{
    [Index(nameof(ProductId), nameof(ShoppingCartId), IsUnique = true)]
    public class ShoppingCartProduct
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double PriceWhenAdded { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }
        
        [Required]
        public int ProductId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public Product Product { get; set; }

    }
}
