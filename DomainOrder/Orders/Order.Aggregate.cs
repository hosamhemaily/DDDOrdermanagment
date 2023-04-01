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
                TotalTaxes = taxes,
                TotalAmount =orderAmountNet+ (orderAmountNet * taxes / 100)
            };
            order.products = orderProducts;
            return order;
        }

        public static Order CancelOrder(Order order)
        {
            if (order.Delivered_YN == null || (bool)order.Delivered_YN)
                throw new Exception("Order delivered");

            order.Canceled_YN= true;
            return order;
        }
        public static Order DeleteOrder(Order order)
        {
            if (order.Delivered_YN == null || (bool)order.Delivered_YN)
                throw new Exception("Order delivered");

            order.Deleted_YN= true;
            return order;
        }

        public static Order Deliverorder(Order order)
        {
            order.Delivered_YN = true;
            return order;
        }
    }
}
