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
    public class NewsController : Controller
    {
        WEBEntities9 objWEBEntities9 = new WEBEntities9();
        // GET: Admin/News
        public ActionResult Index(string currenFilter, string SearchString, int? page)
        {
            var lstNews = new List<News>();
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
                lstNews = objWEBEntities9.News.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstNews = objWEBEntities9.News.ToList();
            }
            ViewBag.currenFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstNews = lstNews.OrderByDescending(n => n.Id).ToList();
            return View(lstNews.ToPagedList(pageNumber, pageSize));
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
        public ActionResult Create(News objNews)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (objNews.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objNews.ImageUpload.FileName);
                        string extension = Path.GetExtension(objNews.ImageUpload.FileName);
                        fileName = fileName  + extension;
                        objNews.Avartar = fileName;
                        objNews.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/avatars/"), fileName));
                    }
                    objNews.CreateOnUtc = DateTime.Now;
                    objWEBEntities9.News.Add(objNews);
                    objWEBEntities9.SaveChanges();

                    return RedirectToAction("Index");
                }

                catch
                {
                    return View();
                }

            }
            return View(objNews);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objNews = objWEBEntities9.News.Where(n => n.Id == id).FirstOrDefault();
            return View(objNews);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objNews = objWEBEntities9.News.Where(n => n.Id == id).FirstOrDefault();
            return View(objNews);
        }
        [HttpPost]
        public ActionResult Delete(News objPro)
        {
            var objNews = objWEBEntities9.News.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWEBEntities9.News.Remove(objNews);
            objWEBEntities9.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objNews = objWEBEntities9.News.Where(n => n.Id == id).FirstOrDefault();
            return View(objNews);
        }
        [HttpPost]
        public ActionResult Edit(int id, News objNews)
        {
            if (objNews.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objNews.ImageUpload.FileName);
                string extension = Path.GetExtension(objNews.ImageUpload.FileName);
                fileName = fileName + extension ;
                objNews.Avartar = fileName;
                objNews.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/avatars/"), fileName));
            }
            objWEBEntities9.Entry(objNews).State = EntityState.Modified;
            objWEBEntities9.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}