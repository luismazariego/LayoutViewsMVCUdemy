using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Models;

namespace EFDbFirstApproachExample.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            //obtiene todos los dataset
            //Gets all dataset (tables in db)
            var db = new EFDBFirstDatabaseEntities();
            
            //linq para obtener el listado de categorias desde la bd.
            //ToList is a Linq method, it gets the list of categories in the dataset (or database table)
            var categories = db.Categories.ToList();

            return View(categories);
        }
    }
}