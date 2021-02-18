using System.ComponentModel.DataAnnotations;

namespace MiniEshop.Models.Actions
{
    public class AddProductToShoppingCart
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
