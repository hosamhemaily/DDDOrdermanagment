using DomainOrder.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainOrder.Repos
{
    public interface IRepoTaxConfiguration
    {
        public bool add(TaxOrderConfigurations taxOrderConfigurations);
        public bool update();
        public bool delete();
        public IList<TaxOrderConfigurations> GetAll();
        public TaxOrderConfigurations GetById();
    }
}
