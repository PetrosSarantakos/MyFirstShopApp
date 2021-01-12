using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.Services;
using MyShop.WebUI.Controllers;
using MyShop.WebUI.Tests.Mocks;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MyShop.WebUI.Tests.Controllers
{
    [TestClass]
    public class BasketControllerTests
    {
        private BasketController _mockedController;
        private IRepository<Basket> baskets;
        private IRepository<Product> products;

        public object BasketSummarytVM { get; private set; }

        public void Setup()
        {
            baskets = new MockContext<Basket>();
            products = new MockContext<Product>();

            var httpContext = new MockHttpContext();

            IBasketService basketService = new BasketService(products, baskets);
            _mockedController = new BasketController(basketService);
            _mockedController.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), _mockedController);
        }

        [TestMethod]
        public void CanAddBasketItem()
        {
            // Arrange
            Setup();

            // Act
            _mockedController.AddToBasket("1");
            Basket basket = baskets.Collection().FirstOrDefault();

            // Assert
            Assert.IsNotNull(basket);
            Assert.AreEqual(1, basket.BasketItems.Count);
            Assert.AreEqual("1", basket.BasketItems.ToList().FirstOrDefault().ProductId);
        }

        [TestMethod]
        public void CanGetSummaryViewModel()
        {
            // Arrange
            Setup();

            products.Insert(new Product() { Id = "1", Price = 10.00m });
            products.Insert(new Product() { Id = "2", Price = 5.00m });

            var basket = new Basket();

            basket.BasketItems.Add(new BasketItem() { ProductId = "1", Quantity = 2 });
            basket.BasketItems.Add(new BasketItem() { ProductId = "2", Quantity = 1 });
            baskets.Insert(basket);

            IBasketService basketService = new BasketService(products, baskets);
            _mockedController = new BasketController(basketService);
            var httpContext = new MockHttpContext();
            httpContext.Request.Cookies.Add(new System.Web.HttpCookie("eCommerceBasket") { Value = basket.Id });
            _mockedController.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), _mockedController);

            var result = _mockedController.BasketSummary() as PartialViewResult;
            var basketSummary = (BasketSummaryVM)result.ViewData.Model;

            Assert.AreEqual(3, basketSummary.BaksetCount);
            Assert.AreEqual(25.00m, basketSummary.BasketTotal);
        }
    }
}
