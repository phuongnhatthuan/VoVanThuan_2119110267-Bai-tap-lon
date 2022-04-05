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
    public class ProductController : Controller
    {
        WEBEntities8 objWEBEntities8 = new WEBEntities8();
        // GET: Admin/Product

        public ActionResult Index(string currenFilter, string SearchString, int? page)
        {
            var lstProduct = new List<Product>();
            if(SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currenFilter;
            }    
            if(!string.IsNullOrEmpty(SearchString))
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
        //-------------------------------------
        
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();

            return View();
        }
        public ActionResult LienHe()
        {

            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    if (objProduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        //ten hinh
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        //png
                        fileName = fileName + extension;
                        //tenhinh.png
                        objProduct.Avatar = fileName;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Context/images/"), fileName));
                    }
                    objProduct.CreateOnUtc = DateTime.Now;
                    objWEBEntities8.Products.Add(objProduct);
                    objWEBEntities8.SaveChanges();

                    return RedirectToAction("Index");
                }

                catch
                {
                    return View();
                }
               
            }
            return View(objProduct);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct = objWEBEntities8.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = objWEBEntities8.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = objWEBEntities8.Products.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWEBEntities8.Products.Remove(objProduct);
            objWEBEntities8.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objProduct = objWEBEntities8.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(int id,Product objProduct)
        {
            if (objProduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + extension + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss"));
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Context/images/"), fileName));
            }
            objWEBEntities8.Entry(objProduct).State = EntityState.Modified;
            objWEBEntities8.SaveChanges();
            return RedirectToAction("Index");
        }
        void LoadData()
        {
            Commo objCommo = new Commo();
            //lay dử liệu danh mục dưới db
            var lstCat = objWEBEntities8.Categorries.ToList();
            //convert sang select list dang value,text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommo.ToSelectList(dtCategory, "Id", "Name");
            //lấy dử liệu thương hiêu dưới DB
            var lstBrand = objWEBEntities8.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            // convert sang select
            ViewBag.ListBrand = objCommo.ToSelectList(dtBrand, "Id", "Name");
            //loại sản phẩm
            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.Id = 01;
            objProductType.Name = "Giảm giá sốc";
            lstProductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.Id = 02;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            // convert sang select
            ViewBag.ProductType = objCommo.ToSelectList(dtProductType, "Id", "Name");
        }
    }
 }