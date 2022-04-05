using Bai_tap_lon.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_tap_lon.Controllers
{
    public class NewsController : Controller
    {
        WEBEntities8 objWEBEntities8 = new WEBEntities8();
        // GET: News
        public ActionResult Index()
        {
            var lstNews = objWEBEntities8.News.ToList();
            return View(lstNews);
        }
    }
}