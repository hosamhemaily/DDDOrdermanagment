using Domain.Helpers;
using DomainOrder.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainOrder.Orders
{
    public partial class TaxOrderConfigurations: IAggregateRoot
    {
        public static TaxOrderConfigurations Create(Guid guid, int percentage)
        {
           
            TaxOrderConfigurations tax = new TaxOrderConfigurations
            {                
                Id = guid,
                TaxPercentage = percentage
            };
            
            return tax;
        }
    }
}
