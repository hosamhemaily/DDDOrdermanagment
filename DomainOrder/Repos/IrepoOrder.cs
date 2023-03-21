using DomainOrder.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainOrder.Repos
{
    public interface IrepoOrder
    {
        public Guid add(Order order);
        public bool update();
        public bool delete();
        public List<Order> GetAll();
        public Order GetById();
    }
}
