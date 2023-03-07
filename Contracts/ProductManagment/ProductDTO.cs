using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ProductManagment
{
    public class ProductDTO
    {
        public string? Name { get; set; }
        public decimal MinimumQuantity { get; set; }
        public int? CurrentQuantity { get; set; }
        public int? CategoryID { get; set; }
    }

    public class ProductUpdate
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
