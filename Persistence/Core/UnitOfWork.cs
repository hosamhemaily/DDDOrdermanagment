using DomainOrder.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderContext _context1;
        public UnitOfWork(OrderContext context)
        {
            _context1= context;
        }
        public bool SaveChanges()
        {
            var result = _context1.SaveChanges();
            return result > 0 ? true : false;
        }
    }
}
