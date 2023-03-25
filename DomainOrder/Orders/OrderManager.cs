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
        IRepoTaxConfiguration _repoTax;
        public OrderManager(IrepoOrder order,IrepoProduct product, IRepoTaxConfiguration repoTax)
        {
            _order = order;
            _product = product;
            _repoTax = repoTax;
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
                if (products.Where(x => x.Id == productinorder.ProductID).FirstOrDefault()== null ||  products.Where(x => x.Id == productinorder.ProductID).FirstOrDefault()?.CurrentQuantity <= productinorder.Quantity)
                {
                    productAvailable= false;
                }
            });
            return productAvailable;
        }

        private bool CheckTotalOfOrders(Order order)
        {
            
            var myproducts =  _product.GetAllByIds(order.products.Select(x => (Guid)x.ProductID).ToArray());
            var total =  myproducts.Sum(x => x.SellPrice);
            var taxes = _repoTax.GetById().TaxPercentage;
            var totalshouldbe = total + (total * taxes / 100);
            if (totalshouldbe == order.TotalAmount)
            {
                return true;
            }
            else return false;
        }

        public bool ValidateCreateOrder(Order order, List<Product> products)
        {
            
            bool expiry = CheckIfOrderProductsExpirationValid(order, products);
            bool quantity =  CheckIfProductsAvailableOrNot(order, products);
            bool total = CheckTotalOfOrders(order);
            if (!expiry && quantity && total)
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
        public bool ValidateCreateOrder(Order order, List<Product> products);
        
    }
}
