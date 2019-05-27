using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutViewExample.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        [Route("Products/Details/{id:range(1,3)?}")]
        public ActionResult Details(int? id)
        {
            var products = new[]
            {
                new {ProductId = 1, ProductName = "iPhone", Cost = 8000},
                new {ProductId = 1, ProductName = "Printer", Cost = 7500},
                new {ProductId = 1, ProductName = "Camera", Cost = 14000},
            };

            if (id == null)
                return Content("Please pass any product id");

            var prodName = "";
            foreach (var product in products)
            {
                if (product.ProductId == id)
                    prodName = product.ProductName;
            }

            return Content(prodName);
        }

        [Route("Products/GetProductId/{productName}")]
        public ActionResult GetProductId(string productName)
        {
            var products = new[]
            {
                new {ProductId = 1, ProductName = "iPhone", Cost = 8000},
                new {ProductId = 1, ProductName = "Printer", Cost = 7500},
                new {ProductId = 1, ProductName = "Camera", Cost = 14000},
            };

            if (productName == null)
                return Content("Please pass any product name");

            var id = 0;
            foreach (var product in products)
            {
                if (product.ProductName == productName)
                    id = product.ProductId;
            }

            return Content(id.ToString());
        }
    }
}