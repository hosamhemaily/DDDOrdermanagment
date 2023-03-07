using Domain.Helpers;
using DomainOrder.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DomainOrder.Products
{
    public partial class Product: Entity
    {
        public string? Name { get; set; }
        public decimal? MinimumQuantity { get; set; }
        public decimal? CurrentQuantity { get; set; }
        public Category? Catregory { get; set; }
        public DateTime? ExpiryDate { get; set; }

     
    }
}
