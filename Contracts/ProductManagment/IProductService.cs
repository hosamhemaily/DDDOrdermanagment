using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ProductManagment
{
    public interface IProductService
    {
        bool CreateProduct(ProductDTO product);

        bool UpdateProduct(ProductUpdate update);

        public List<ProductDTO> GetProducts();

    }

}
