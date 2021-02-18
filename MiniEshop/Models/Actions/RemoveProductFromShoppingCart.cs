using System.ComponentModel.DataAnnotations;

namespace MiniEshop.Models.Actions
{
    public class RemoveProductFromShoppingCart
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int ShoppingCartId { get; set; }
    }
}
 