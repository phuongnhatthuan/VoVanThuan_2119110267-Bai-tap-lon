using Bai_tap_lon.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_tap_lon.Areas.Admin.Controllers
{
    public class OrderDetailController : Controller
    {
        WEBEntities9 objWEBEntities9 = new WEBEntities9();
        // GET: Admin/OrderDetail
        public ActionResult Index(string currenFilter, string SearchString, int? page)
        {
            var lstOrderDetail = new List<OrderDetail>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currenFilter;
            }
            //if (!string.IsNullOrEmpty(SearchString))
            //{
            //    lstOrderDetail = objWEBEntities9.OrderDetails.Where(n => n.Id.Contains(SearchString)).ToList();
            //}
            //else
            //{
            //    lstOrderDetail = objWEBEntities9.OrderDetails.ToList();
            //}
            ViewBag.currenFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstOrderDetail = lstOrderDetail.OrderByDescending(n => n.Id).ToList();
            return View(lstOrderDetail.ToPagedList(pageNumber, pageSize));
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
        public ActionResult Create(OrderDetail objOrderDetail)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    objWEBEntities9.OrderDetails.Add(objOrderDetail);
                    objWEBEntities9.SaveChanges();

                    return RedirectToAction("Index");
                }

                catch
                {
                    return View();
                }

            }
            return View(objOrderDetail);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objOrderDetail = objWEBEntities9.OrderDetails.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrderDetail);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objOrderDetail = objWEBEntities9.OrderDetails.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrderDetail);
        }
        [HttpPost]
        public ActionResult Delete(News objPro)
        {
            var objOrderDetail = objWEBEntities9.OrderDetails.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWEBEntities9.OrderDetails.Remove(objOrderDetail);
            objWEBEntities9.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objOrderDetail = objWEBEntities9.OrderDetails.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrderDetail);
        }
        [HttpPost]
        public ActionResult Edit(int id, OrderDetail objOrderDetail)
        {

            objWEBEntities9.Entry(objOrderDetail).State = EntityState.Modified;
            objWEBEntities9.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}