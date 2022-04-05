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
        WEBEntities8 objWEBEntities8 = new WEBEntities8();
        // GET: Contact
        public ActionResult Index()
        {
            var lstContact = objWEBEntities8.Contacts.ToList();
           
            return View(lstContact);
        }
    }
}