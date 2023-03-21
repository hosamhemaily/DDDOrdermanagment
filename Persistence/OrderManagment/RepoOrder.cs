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
    public class RepoOrder : IrepoOrder
    {
        OrderContext _orderContext;
        public RepoOrder(OrderContext orderContext)
        {
            _orderContext= orderContext;
        }
        public Guid add(Order order)
        {
            _orderContext.Add(order);
            _orderContext.SaveChanges();
            return new Guid();
        }

        public bool delete()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById()
        {
            throw new NotImplementedException();
        }

        public bool update()
        {
            throw new NotImplementedException();
        }
    }
}
