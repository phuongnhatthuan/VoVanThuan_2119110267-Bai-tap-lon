using Bai_tap_lon.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai_tap_lon.Controllers
{
    public class ContactController : Controller
    {
        WEBEntities9 objWEBEntities9 = new WEBEntities9();
        // GET: Contact
        public ActionResult Index()
        {
            var lstContact = objWEBEntities9.Contacts.ToList();
           
            return View(lstContact);
        }
    }
}