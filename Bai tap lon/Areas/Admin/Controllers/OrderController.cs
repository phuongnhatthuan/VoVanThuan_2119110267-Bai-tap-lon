using Bai_tap_lon.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_tap_lon.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        WEBEntities9 objWEBEntities9 = new WEBEntities9();
        // GET: Admin/Order
        public ActionResult Index(string currenFilter, string SearchString, int? page)
        {
            var lstOrder = new List<Order>();
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
                lstOrder = objWEBEntities9.Orders.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstOrder = objWEBEntities9.Orders.ToList();
            }
            ViewBag.currenFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstOrder = lstOrder.OrderByDescending(n => n.Id).ToList();
            return View(lstOrder.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        public ActionResult LienHe()
        {

            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Order objOrder)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    objWEBEntities9.Orders.Add(objOrder);
                    objWEBEntities9.SaveChanges();

                    return RedirectToAction("Index");
                }

                catch
                {
                    return View();
                }

            }
            return View(objOrder);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objOrder = objWEBEntities9.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrder);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objOrder = objWEBEntities9.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrder);
        }
        [HttpPost]
        public ActionResult Delete(News objPro)
        {
            var objOrder = objWEBEntities9.Orders.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWEBEntities9.Orders.Remove(objOrder);
            objWEBEntities9.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objOrder = objWEBEntities9.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrder);
        }
        [HttpPost]
        public ActionResult Edit(int id, Order objOrder)
        {
           
            objWEBEntities9.Entry(objOrder).State = EntityState.Modified;
            objWEBEntities9.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}