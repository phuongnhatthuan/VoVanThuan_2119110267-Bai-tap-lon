using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai_tap_lon.Context;

namespace Bai_tap_lon.Controllers
{
    public class ProductController : Controller
    {
        WEBEntities7 objWEBEntities7 = new WEBEntities7();
        // GET: Product
        public ActionResult Detail(int Id)
            {
            var objProduct = objWEBEntities7.Products.Where(n => n.Id == Id) .FirstOrDefault();
            return View(objProduct);
        }
    }
}