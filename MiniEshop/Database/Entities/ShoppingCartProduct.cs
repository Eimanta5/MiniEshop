namespace MiniEshop.Database.Entities
{
    public class ShoppingCartProduct
    {
        public int ShoppingCartProductId { get; set; }
        public int ProductId { get; set; }
        public int ShoppingCartId { get; set; }
        public int Quantity { get; set; }
        public double? PriceWhenSold { get; set; }
    }
}
