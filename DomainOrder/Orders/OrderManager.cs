using DomainOrder.Helpers;
using DomainOrder.Products;
using DomainOrder.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainOrder.Orders
{
    class OrderManager : IDomainService, IOrderManager
    {
        IrepoOrder _order;
        IrepoProduct _product;
        public OrderManager(IrepoOrder order,IrepoProduct product)
        {
            _order= order;
            _product= product;
        }
        public bool CheckIfOrderProductsExpirationValid(Order order, List<Product> products)
        {
            bool expirationvalid_YN = true;
            products.ForEach(product =>
            {
                if (product.ExpiryDate <= DateTime.Now) 
                {
                    expirationvalid_YN = false;
                }
            });
            return expirationvalid_YN;
        }

        public bool CheckIfProductsAvailableOrNot(Order order,List<Product> products)
        {
            bool productAvailable = true;
            order.products?.ForEach(productinorder =>
            {
                if (products.Where(x => x.Id == productinorder.ProductID).FirstOrDefault()?.CurrentQuantity <= productinorder.Quantity)
                {
                    productAvailable= false;
                }
            });
            return productAvailable;
        }

        public bool ValidateCreateOrder(Order order, List<Product> products)
        {
            bool expiry = CheckIfOrderProductsExpirationValid(order, products);
            bool quantity =  CheckIfProductsAvailableOrNot(order, products);
            if (expiry && quantity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public interface IOrderManager
    {
        public bool CheckIfProductsAvailableOrNot(Order order, List<Product> products);

        public bool CheckIfOrderProductsExpirationValid(Order order,List<Product> products);

        public bool ValidateCreateOrder(Order order, List<Product> products);
    }
}
