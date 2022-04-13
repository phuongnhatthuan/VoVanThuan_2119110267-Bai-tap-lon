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
    public class UserController : Controller
    {
        WEBEntities9 objWEBEntities9 = new WEBEntities9();
        // GET: Admin/User
        public ActionResult Index(string currentFileter, string SearchString, int? page)
        {
            var lstUser = new List<User>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFileter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstUser = objWEBEntities9.Users.Where(n => n.FirstName.Contains(SearchString)).ToList();
            }
            else
            {
                lstUser = objWEBEntities9.Users.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstUser = lstUser.OrderByDescending(n => n.Id).ToList();
            return View(lstUser);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(User objUser)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    /*if (objBrand.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                        string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objBrand.Avatar = fileName;
                        objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/Brand/"), fileName));
                    }
                    */
                    objWEBEntities9.Users.Add(objUser);
                    objWEBEntities9.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(objUser);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objUser = objWEBEntities9.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objUser = objWEBEntities9.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }
        public ActionResult Delete(User objPro)
        {
            var objUser = objWEBEntities9.Users.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWEBEntities9.Users.Remove(objUser);
            objWEBEntities9.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objUser = objWEBEntities9.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }
        [HttpPost]
        public ActionResult Edit(int id, User objUser)
        {

            objWEBEntities9.Entry(objUser).State = EntityState.Modified;
            objWEBEntities9.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}