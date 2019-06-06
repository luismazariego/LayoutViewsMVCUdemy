using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelExample.Models
{
    public class CustomBinder: IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            int StudentId = Convert.ToInt16(controllerContext.HttpContext.Request.Form["StudentId"]);
            var StudentName = controllerContext.HttpContext.Request.Form["StudentName"];
            var DNo = controllerContext.HttpContext.Request.Form["DNo"];
            var Street = controllerContext.HttpContext.Request.Form["Street"];
            var Landmark = controllerContext.HttpContext.Request.Form["Landmark"];
            var City = controllerContext.HttpContext.Request.Form["City"];

            return new Student()
            {
                StudentId = StudentId, StudentName = StudentName, Address = DNo + ", " +
                                                                            Street + ", " +
                                                                            Landmark + ", " +
                                                                            City
            };
        }
    }
}