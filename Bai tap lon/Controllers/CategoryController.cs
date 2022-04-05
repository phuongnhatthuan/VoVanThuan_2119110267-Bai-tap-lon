using Bai_tap_lon.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_tap_lon.Controllers
{
    public class CategoryController : Controller
    {
        WEBEntities8 objWEBEntities8 = new WEBEntities8();
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = objWEBEntities8.Categorries.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var listProduct = objWEBEntities8.Products.Where(n => n.CategoryId == Id).ToList();
            return View(listProduct);
        }
        
    }
}