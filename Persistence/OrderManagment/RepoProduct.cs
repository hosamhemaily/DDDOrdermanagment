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
    public class RepoProduct : IrepoProduct
    {
        OrderContext _orderContext;
        public RepoProduct(OrderContext orderContext)
        {
            _orderContext= orderContext;
        }
        public bool add(Product order)
        {
            _orderContext.Add(order);
            _orderContext.SaveChanges();
            return true;
        }

        public bool delete()
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            return _orderContext.Products.ToList();
        }

        public IList<Product> GetAllByIds(Guid[] ids)
        {
            throw new NotImplementedException();
        }

        public Product GetById()
        {
            throw new NotImplementedException();
        }

        public bool update()
        {
            throw new NotImplementedException();
        }
    }
}
