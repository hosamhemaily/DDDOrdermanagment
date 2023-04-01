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
        public string? Name { get; protected set; }
        public decimal? MinimumQuantity { get; protected set; }
        public decimal? CurrentQuantity { get; protected set; }
        public DateTime? ExpiryDate { get; protected set; }
        public decimal SellPrice { get; protected set; }

     
    }
}
