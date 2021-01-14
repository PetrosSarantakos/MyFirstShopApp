using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Services
{
    public class OrderService:IOrderService
    {
        private IRepository<Order> _ordersContext;
        public OrderService(IRepository<Order> ordersContext)
        {
            _ordersContext = ordersContext;
        }

        public void CreateOrder(Order baseOrder, List<BasketItemVM> basketItems)
        {
            foreach (var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId=item.Id,
                    Image = item.ImageURL,
                    Price=item.Price,
                    ProductName=item.ProductName,
                    Quantity=item.Quantity
                });
            }

            _ordersContext.Insert(baseOrder);
            _ordersContext.Commit();
        }
    }
}
