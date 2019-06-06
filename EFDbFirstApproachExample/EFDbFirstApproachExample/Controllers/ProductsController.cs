using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Models;

namespace EFDbFirstApproachExample.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(string search = "")
        {
            var db = new EFDBFirstDatabaseEntities();

            //Conditional retrieve of items using Where method from linq.
            //temp is a optional name related to the model, in this case the model is the same as the dataset
            //dataset = model = Products.
            //var products = db.Products.Where(temp => temp.CategoryID == 1 && temp.Price >= 50000).ToList();

            //Here the condition is related to the search box in the view.
            var products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();

            //to show the search term after it is submitted.
            ViewBag.Search = search;

            return View(products);
        }

        public ActionResult Details(long id)
        {
            var db = new EFDBFirstDatabaseEntities();

            //this is the way showed by the instructor.
            var product = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            
            //More practical retrieve of data
            //var product = db.Products.FirstOrDefault(temp => temp.ProductID == id);

            return View(product);
        }
    }
}