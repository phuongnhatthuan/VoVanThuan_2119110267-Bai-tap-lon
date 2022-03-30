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
        WEBEntities7 objWEBEntities7 = new WEBEntities7();
        // GET: Brand
        public ActionResult Index()
        {

            var lstBrand = objWEBEntities7.Brands.ToList();
            return View(lstBrand);
        }
        public ActionResult ProductBand()
        {

            
            return View();
        }
    }
}