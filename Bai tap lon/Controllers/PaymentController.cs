using Bai_tap_lon.Context;
using Bai_tap_lon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_tap_lon.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        WEBEntities9 objWEBEntities9 = new WEBEntities9();
        public ActionResult Index()
        {   
            if(Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }    
            else
            {
                //lấy thông từ giỏi hàng từ biến se
                var lstCart = (List<CartModel>)Session["cart"];
                // gán dữ liệu
                Order objOrder = new Order();
                objOrder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                objWEBEntities9.Orders.Add(objOrder);
                // lưu thông tin
                objWEBEntities9.SaveChanges();
                //lấy order
                int intOrderId = objOrder.Id;
                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                foreach(var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Quantity = item.Quantity;
                    obj.OrderId = intOrderId;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetail.Add(obj);
                }
                objWEBEntities9.OrderDetails.AddRange(lstOrderDetail);
                objWEBEntities9.SaveChanges();
            }
            return View();
           
        }
        
    }
}