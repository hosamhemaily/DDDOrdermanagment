using Contracts.OrderManagment;
using MassTransit;
using SharedAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class OrderFailedConsumer : IConsumer<OrderFailed>
    {
        IOrderService _orderService;
        public OrderFailedConsumer(IOrderService orderService)
        {
            _orderService= orderService;
        }
        public async Task Consume(ConsumeContext<OrderFailed> context)
        {
             _orderService.DeleteOrder(context.Message.id);
        }
    }
}
