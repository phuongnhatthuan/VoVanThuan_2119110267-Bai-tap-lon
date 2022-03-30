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
        WEBEntities7 objWEBEntities7 = new WEBEntities7();
        // GET: Contact
        public ActionResult Index()
        {
            var lstContact = objWEBEntities7.Contacts.ToList();
           
            return View(lstContact);
        }
    }
}