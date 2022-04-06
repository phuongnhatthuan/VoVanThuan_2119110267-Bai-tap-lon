using Bai_tap_lon.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_tap_lon.Controllers
{
    public class BrandController : Controller
    {
        WEBEntities9 objWEBEntities9 = new WEBEntities9();
        // GET: Brand
        public ActionResult Index()
        {

            var lstBrand = objWEBEntities9.Brands.ToList();
            return View(lstBrand);
        }
        public ActionResult ProductBand()
        {

            
            return View();
        }
    }
}