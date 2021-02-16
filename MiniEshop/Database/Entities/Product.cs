using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniEshop.Database.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
