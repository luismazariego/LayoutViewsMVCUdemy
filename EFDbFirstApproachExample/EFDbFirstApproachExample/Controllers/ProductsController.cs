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
        public ActionResult Index(string search = "", string SortColumn = "ProductName", string IconClass="fa-sort-asc", int PageNo = 1)
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

            //Sorting
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            if (ViewBag.SortColumn == "ProductID")
            {
                products = ViewBag.IconClass == "fa-sort-asc" 
                    ? products.OrderBy(temp => temp.ProductID).ToList() 
                    : products.OrderByDescending(temp => temp.ProductID).ToList();
            }

            else if (ViewBag.SortColumn == "ProductName")
            {
                products = ViewBag.IconClass == "fa-sort-asc" 
                    ? products.OrderBy(temp => temp.ProductName).ToList() 
                    : products.OrderByDescending(temp => temp.ProductName).ToList();
            }

            else if (ViewBag.SortColumn == "Price")
            {
                products = ViewBag.IconClass == "fa-sort-asc" 
                    ? products.OrderBy(temp => temp.Price).ToList() 
                    : products.OrderByDescending(temp => temp.Price).ToList();
            }

            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                products = ViewBag.IconClass == "fa-sort-asc"
                    ? products.OrderBy(temp => temp.AvailabilityStatus).ToList()
                    : products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
            }

            else if (ViewBag.SortColumn == "CategoryID")
            {
                products = ViewBag.IconClass == "fa-sort-asc"
                    ? products.OrderBy(temp => temp.CategoryID).ToList()
                    : products.OrderByDescending(temp => temp.CategoryID).ToList();
            }

            else if (ViewBag.SortColumn == "BrandID")
            {
                products = ViewBag.IconClass == "fa-sort-asc"
                    ? products.OrderBy(temp => temp.BrandID).ToList()
                    : products.OrderByDescending(temp => temp.BrandID).ToList();
            }

            //Paging
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();

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
            var db = new EFDBFirstDatabaseEntities();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            var db = new EFDBFirstDatabaseEntities();

            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                //doesn't work
                //var imgBytes = new Byte[file.ContentLength - 1];
                var imgBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                product.Photo = base64String;
            }

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

            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();

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