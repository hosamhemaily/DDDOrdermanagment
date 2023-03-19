using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ProductManagment
{
    public class ProductContractDTO
    {
        public string? name { get; set; }
        public decimal? MinimumQuantity { get; set; }
        public decimal? CurrentQuantity { get; set; }
        public Guid? CategoryID { get; set; }
        public Guid ProductId { get; set; }
    }

    public class ProductUpdate
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
