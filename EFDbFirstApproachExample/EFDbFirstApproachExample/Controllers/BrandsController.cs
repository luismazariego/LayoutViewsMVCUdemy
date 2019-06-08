using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Models;

namespace EFDbFirstApproachExample.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            //version of db first approach
            //var db = new EFDBFirstDatabaseEntities();

            //version of code first approach
            var db = new CompanyDbContext();

            var brands = db.Brands.ToList();

            return View(brands);
        }
    }
}