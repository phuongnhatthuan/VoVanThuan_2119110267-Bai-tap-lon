using Bai_tap_lon.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_tap_lon.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        WEBEntities9 objWEBEntities9 = new WEBEntities9();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public long Tinhsothanhvien()
        {
            var s = objWEBEntities9.Users.Count();
            return s;
          
        }

    }
}