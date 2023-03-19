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
        public bool CreateProduct(ProductContractDTO product)
        {
            var myproduct =  Product.Create(product?.name, product.MinimumQuantity, new Guid());
            _productRepo.add(myproduct);
            return true;
        }

        public List<ProductContractDTO> GetProducts()
        {
            var prs = _productRepo.GetAll();
            var products =  prs.Select(x => new ProductContractDTO{
                name= x.Name,
                CategoryID  =x.Catregory?.Id,
                CurrentQuantity=x.CurrentQuantity,
                MinimumQuantity = x.MinimumQuantity
               
            }).ToList();
            
            return products;
        }

        public bool UpdateProduct(ProductUpdate update)
        {
            throw new NotImplementedException();
        }
    }
}
