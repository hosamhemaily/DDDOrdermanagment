using Domain.Helpers;
using DomainOrder.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainOrder.Orders
{
    public partial class Order : IAggregateRoot
    {
        public static Order CreateOrder(Guid guid, decimal? orderAmountNet, string customer, decimal taxes, List<OrderProduct> orderProducts)
        {
            taxes = taxes == 0 ? throw new ArgumentNullException(nameof(taxes)) : taxes;
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
