using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using MyShop.WebUI;
using MyShop.WebUI.Controllers;

namespace MyShop.WebUI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexPageReturnsProducts()
        {
            // Arrange
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<ProductCategory> producCategoryContext = new Mocks.MockContext<ProductCategory>();
            HomeController controller = new HomeController(productContext,producCategoryContext);

            productContext.Insert(new Product());

            // Act
            var result = controller.Index() as ViewResult;
            var viewModel = (ProductListVM)result.ViewData.Model;

            // Assert
            Assert.AreEqual(1,viewModel.Products.Count());
        }

        [TestMethod]
        public void About()
        {
            //// Arrange
            //HomeController controller = new HomeController();

            //// Act
            //ViewResult result = controller.About() as ViewResult;

            //// Assert
            //Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            //// Arrange
            //HomeController controller = new HomeController();

            //// Act
            //ViewResult result = controller.Contact() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
        }
    }
}
