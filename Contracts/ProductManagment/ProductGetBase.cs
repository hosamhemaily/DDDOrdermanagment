using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class ProductGetBase
    {
        public string? name { get; set; }
        public decimal? MinimumQuantity { get; set; }
        public decimal? CurrentQuantity { get; set; }
        public Guid? Catregory { get;  set; }
        public DateTime? ExpiryDate { get;  set; }
        public decimal SellPrice { get; set; }
        public Guid ProductId { get; set; }

    }
}
