using Contracts.OrderManagment;
using Contracts.ProductManagment;
using DomainOrder.Products;
using Microsoft.AspNetCore.Mvc;

namespace DDDOrdermanagment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        
        
        [HttpGet(Name = "get")]
        public IList<ProductContractDTO> Get()
        {
            return new List<ProductContractDTO>() 
            {
                new ProductContractDTO { CategoryID = new Guid(), MinimumQuantity =100 , CurrentQuantity = 10, name="product 1" },
                new ProductContractDTO { CategoryID = new Guid(), MinimumQuantity =200 , CurrentQuantity = 20, name="product 2" }
           };
            
        }
    }
}