using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniEshop.Database.Entities
{
    public class ShoppingCartProduct
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        public double PriceWhenAdded { get; set; }

        [Required]
        public ShoppingCart ShoppingCart { get; set; }

        public int ShoppingCartId { get; set; }

        [Required]
        public Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
