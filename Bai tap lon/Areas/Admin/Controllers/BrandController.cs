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
    public class BrandController : Controller
    {
        WEBEntities9 objWEBEntities9 = new WEBEntities9();
        // GET: Admin/News
        public ActionResult Index(string currenFilter, string SearchString, int? page)
        {
            var lstBrand = new List<Brand>();
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
                lstBrand = objWEBEntities9.Brands.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstBrand = objWEBEntities9.Brands.ToList();
            }
            ViewBag.currenFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstBrand = lstBrand.OrderByDescending(n => n.Id).ToList();
            return View(lstBrand.ToPagedList(pageNumber, pageSize));
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
        public ActionResult Create(Brand objBrand)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (objBrand.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                        string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                        fileName = fileName  + extension;
                        objBrand.Avatar = fileName;
                        objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
                    }
                    objBrand.CreateOnUtc = DateTime.Now;
                    objWEBEntities9.Brands.Add(objBrand);
                    objWEBEntities9.SaveChanges();

                    return RedirectToAction("Index");
                }

                catch
                {
                    return View();
                }

            }
            return View(objBrand);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objBrand = objWEBEntities9.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objBrand = objWEBEntities9.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Delete(News objPro)
        {
            var objBrand = objWEBEntities9.Brands.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWEBEntities9.Brands.Remove(objBrand);
            objWEBEntities9.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objBrand = objWEBEntities9.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Edit(int id, Brand objBrand)
        {
            if (objBrand.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                fileName = fileName + extension ;
                objBrand.Avatar = fileName;
                objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/avatars"), fileName));
            }
            objWEBEntities9.Entry(objBrand).State = EntityState.Modified;
            objWEBEntities9.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}