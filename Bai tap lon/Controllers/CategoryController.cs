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
        WEBEntities7 objWEBEntities7 = new WEBEntities7();
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = objWEBEntities7.Categorries.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var listProduct = objWEBEntities7.Products.Where(n => n.CategoryId == Id).ToList();
            return View(listProduct);
        }
        
    }
}