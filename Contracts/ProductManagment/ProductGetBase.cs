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
        public decimal? minimumQuantity { get; set; }
        public decimal? currentQuantity { get; set; }
        public Guid? catregory { get;  set; }
        public DateTime? expiryDate { get;  set; }
        public decimal sellPrice { get; set; }
        public Guid productId { get; set; }

    }
}
