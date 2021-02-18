using System.ComponentModel.DataAnnotations;

namespace MiniEshop.Models.Actions
{
    public class UpdateProduct
    {
        public int Quantity { get; set; }

        public double Price { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }
     
        [MaxLength(2560)]
        public string Description { get; set; }
    }
}
