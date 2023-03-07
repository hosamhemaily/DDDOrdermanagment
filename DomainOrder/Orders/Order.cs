using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainOrder.Orders
{
    public class Order : Entity
    {
        public decimal? OrderAmountNet { get; protected set; }
        public string? CustomerID { get; protected set; }
        public decimal? TotalTaxes { get; protected set; }
        public decimal? TotalAmount { get; protected set; }
        public bool? Canceled_YN { get; protected set; }
        public List<OrderProduct>? products { get; protected set; }
        public static Order CreateOrder(Guid guid,decimal? orderAmountNet,string customer,decimal taxes,List<OrderProduct> orderProducts)
        {
            taxes = taxes == 0 ?  throw new ArgumentNullException(nameof(taxes)) : taxes;
            Order order = new Order
            {
                CustomerID = customer,
                Id = guid,
                OrderAmountNet = orderAmountNet,
                TotalTaxes = taxes
            };
            order.products = orderProducts;
            return order;
        }
    }
}
