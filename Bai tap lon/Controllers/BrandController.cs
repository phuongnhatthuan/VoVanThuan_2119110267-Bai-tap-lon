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
        WEBEntities8 objWEBEntities8 = new WEBEntities8();
        // GET: Brand
        public ActionResult Index()
        {

            var lstBrand = objWEBEntities8.Brands.ToList();
            return View(lstBrand);
        }
        public ActionResult ProductBand()
        {

            
            return View();
        }
    }
}