using Contracts.OrderManagment;
using Contracts.ProductManagment;
using Microsoft.AspNetCore.Mvc;

namespace DDDOrdermanagment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<OrderController> _logger;

        public ProductController(ILogger<OrderController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost(Name = "create")]
        public bool Create(ProductDTO product)
        {
            _productService.CreateProduct(product);
            return true;
        }
    }
}