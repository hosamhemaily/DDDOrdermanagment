using DomainOrder.Orders;
using DomainOrder.Products;
using DomainOrder.Repos;
using Persistence.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.OrderManagment
{
    public class RepoTaxConfiguration : IRepoTaxConfiguration
    {
        OrderContext _orderContext;
        public RepoTaxConfiguration(OrderContext orderContext)
        {
            _orderContext= orderContext;
        }
        public bool add(TaxOrderConfigurations order)
        {
            _orderContext.Add(order);
            _orderContext.SaveChanges();
            return true;
        }

        public bool delete()
        {
            throw new NotImplementedException();
        }

        public IList<TaxOrderConfigurations> GetAll()
        {
            return _orderContext.TaxOrderConfigurations.ToList();
        }

        public TaxOrderConfigurations GetById()
        {
            return _orderContext.TaxOrderConfigurations.FirstOrDefault();
        }

        public bool update()
        {
            throw new NotImplementedException();
        }
    }
}
