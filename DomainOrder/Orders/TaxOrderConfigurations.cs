using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainOrder.Orders
{
    public partial class TaxOrderConfigurations: Entity
    {
        public int TaxPercentage { get; set; }
    }
}
