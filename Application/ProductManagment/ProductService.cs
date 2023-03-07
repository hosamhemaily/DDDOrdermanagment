using Contracts.ProductManagment;
using DomainOrder.Products;
using DomainOrder.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductManagment
{
    public class ProductService : IProductService
    {
        IrepoProduct _productRepo;
        public ProductService(IrepoProduct productRepo) 
        {
            _productRepo = productRepo;
        }
        public bool CreateProduct(ProductDTO product)
        {
            var myproduct =  Product.Create(product?.Name, product.MinimumQuantity, new Guid());
            _productRepo.add(myproduct);
            return true;
        }

        public List<ProductDTO> GetProducts()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(ProductUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
