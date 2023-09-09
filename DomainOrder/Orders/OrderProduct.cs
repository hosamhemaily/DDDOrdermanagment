using Domain.Helpers;
using DomainOrder.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainOrder.Orders
{
    public class OrderProduct : Entity
    {
        public Guid? ProductID { get; protected set; }
        public decimal? Quantity { get; protected set; }

        public static OrderProduct CreateOrderProduct(Guid ProductID, decimal? Quantity)
        {
            OrderProduct orderProduct = new OrderProduct
            {
                Quantity = Quantity,
                ProductID = ProductID                
            };
            
            return orderProduct;
        }

    }
}
