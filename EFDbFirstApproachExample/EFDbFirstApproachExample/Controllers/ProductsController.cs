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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            var db = new EFDBFirstDatabaseEntities();

            db.Products.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            var db = new EFDBFirstDatabaseEntities();

            //as showed in the course
            var existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();

            //More short way
            //var existingProduct = db.Products.FirstOrDefault(temp => temp.ProductID == id);

            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var db = new EFDBFirstDatabaseEntities();

            var existingProduct = db.Products.Where(temp => temp.ProductID == product.ProductID).FirstOrDefault();

            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.DateOfPurchase = product.DateOfPurchase;
            existingProduct.AvailabilityStatus = product.AvailabilityStatus;
            existingProduct.BrandID = product.BrandID;
            existingProduct.CategoryID = product.CategoryID;
            existingProduct.Active = product.Active;
            
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            var db = new EFDBFirstDatabaseEntities();

            var existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();

            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Delete(long id, Product p)
        {
            var db = new EFDBFirstDatabaseEntities();

            var existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();

            db.Products.Remove(existingProduct);
            db.SaveChanges();

            return RedirectToAction("Index", "Products");
        }


    }
}