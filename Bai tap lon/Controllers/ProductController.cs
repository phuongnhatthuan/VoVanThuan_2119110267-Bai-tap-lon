using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai_tap_lon.Context;
using PagedList;

namespace Bai_tap_lon.Controllers
{
    public class ProductController : Controller
    {
        WEBEntities8 objWEBEntities8 = new WEBEntities8();
        // GET: Product
        public ActionResult Detail(int Id)
            {
            var objProduct = objWEBEntities8.Products.Where(n => n.Id == Id) .FirstOrDefault();
            return View(objProduct);
        }
        public ActionResult Index(string currenFilter, string SearchString, int? page)
        {
            var lstProduct = new List<Product>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currenFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstProduct = objWEBEntities8.Products.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstProduct = objWEBEntities8.Products.ToList();
            }
            ViewBag.currenFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }
    }
}