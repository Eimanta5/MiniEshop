using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniEshop.Database.Entities
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public bool isActive { get; set; }
        public int UserId { get; set; }
    }
}
