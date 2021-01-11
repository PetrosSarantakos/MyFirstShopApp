using MyShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        // GET: Basket
        public ActionResult Index()
        {
            var model = _basketService.GetBasketItems(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToBasket(string id)
        {
            _basketService.AddToBasket(this.HttpContext, id);

            return RedirectToAction("Index","Home");
        }

        public ActionResult RemoveFromBasket(string id)
        {
            _basketService.RemoveFromBasket(this.HttpContext, id);

            return RedirectToAction("Index");
        }

        public PartialViewResult BasketSummary()
        {
            var basketSummary = _basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }
    }
}