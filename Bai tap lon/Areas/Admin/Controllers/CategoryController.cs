using Bai_tap_lon.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_tap_lon.Areas.Admin.Controllers
{
    public class CategoryController : Controller

    {
        WEBEntities9 objWEBEntities9 = new WEBEntities9();
        // GET: Admin/Category
        public ActionResult Index(string currenFilter, string SearchString, int? page)
        {
            var lstCat = new List<Categorry>();
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
                lstCat = objWEBEntities9.Categorries.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstCat = objWEBEntities9.Categorries.ToList();
            }
            ViewBag.currenFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstCat = lstCat.OrderByDescending(n => n.Id).ToList();
            return View(lstCat.ToPagedList(pageNumber, pageSize));
        }
        //-------------------------------------

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
        public ActionResult Create(Categorry objCategorry)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (objCategorry.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objCategorry.ImageUpload.FileName);
                        string extension = Path.GetExtension(objCategorry.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objCategorry.Avatar = fileName;
                        objCategorry.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/category/"), fileName));
                    }
                    objCategorry.CreateOnUtc = DateTime.Now;
                    objWEBEntities9.Categorries.Add(objCategorry);
                    objWEBEntities9.SaveChanges();

                    return RedirectToAction("Index");
                }

                catch
                {
                    return View();
                }

            }
            return View(objCategorry);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objCategorry = objWEBEntities9.Categorries.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategorry);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objCategorry = objWEBEntities9.Categorries.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategorry);
        }
        [HttpPost]
        public ActionResult Delete(Categorry objPro)
        {
            var objCategorry = objWEBEntities9.Categorries.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWEBEntities9.Categorries.Remove(objCategorry);
            objWEBEntities9.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objCategorry = objWEBEntities9.Categorries.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategorry);
        }
        [HttpPost]
        public ActionResult Edit(int id, Categorry objCategorry)
        {
            if (objCategorry.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objCategorry.ImageUpload.FileName);
                string extension = Path.GetExtension(objCategorry.ImageUpload.FileName);
                fileName = fileName + extension ;
                objCategorry.Avatar = fileName;
                objCategorry.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
            }
            objWEBEntities9.Entry(objCategorry).State = EntityState.Modified;
            objWEBEntities9.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}