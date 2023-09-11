using Contracts.OrderManagment;
using Microsoft.AspNetCore.Mvc;

namespace DDDOrdermanagment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpPost("add")]
        public bool Create(OrderDTO order)
        {
            return _orderService.CreateOrder(order)!=null ? true:false;
        } 
        
        [HttpPost("cancel")]
        public bool Cancel(Guid id)
        {
            _orderService.CancelOrder(id);
            return true;
        }
    }
}