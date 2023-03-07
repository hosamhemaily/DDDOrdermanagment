using DomainOrder.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainOrder.Orders
{
    public class ProductDTO
    {
        public Product? Product { get; protected set; }
        public decimal? Quantity { get; protected set; }
        public decimal? PurshasePrice { get; protected set; }
      
    }
}
