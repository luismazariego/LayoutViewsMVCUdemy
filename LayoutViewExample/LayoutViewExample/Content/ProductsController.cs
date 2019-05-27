using System.Web.Mvc;

namespace LayoutViewExample.Content
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int? id)
        {
            var products = new[]
            {
                new {ProductId = 1, ProductName = "Phone", Cost = 8000},
                new {ProductId = 2, ProductName = "Printer", Cost = 7500},
                new {ProductId = 3, ProductName = "Camera", Cost = 14000}
            };
            if (id == null)
                return Content("Please pass any product id");

            var prodName = "";
            foreach (var product in products)
            {
                if (product.ProductId == id)
                {
                    prodName = product.ProductName;
                }
            }
            return Content(prodName);
        }

        public ActionResult GetProductId(string productName)
        {
            var products = new[]
            {
                new {ProductId = 1, ProductName = "Phone", Cost = 8000},
                new {ProductId = 2, ProductName = "Printer", Cost = 7500},
                new {ProductId = 3, ProductName = "Camera", Cost = 14000}
            };

            if (productName == null)
                return Content("Please pass any product name");

            var prodId = 0;
            foreach (var product in products)
            {
                if (product.ProductName == productName)
                {
                    prodId = product.ProductId;
                }
            }
            return Content(prodId.ToString());
        }
    }
}