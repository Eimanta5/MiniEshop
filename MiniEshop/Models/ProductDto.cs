namespace MiniEshop.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
