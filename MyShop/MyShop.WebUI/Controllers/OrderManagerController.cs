using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderManagerController : Controller
    {
        IOrderService _orderService;
        public OrderManagerController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: OrderManager
        public ActionResult Index()
        {
            List<Order> orders = _orderService.GetOrderList();
            return View(orders);
        }
        public ActionResult UpdateOrder(string id)
        {
            ViewBag.StatusList = new List<string>()
            {
                "Order Created", "Shipped" , "Completed"
            };
            Order order = _orderService.GetOrder(id);
            return View(order);
        }

        [HttpPost]
        public ActionResult UpdateOrder(Order updatedOrder, string id)
        {
            Order order = _orderService.GetOrder(id);
            order.OrderStatus = updatedOrder.OrderStatus;

            return RedirectToAction("Index");
        }
    }
}