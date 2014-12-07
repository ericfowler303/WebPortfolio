using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {
        Models.sp5EricEntities contactDb = new Models.sp5EricEntities();

        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendContact(FormCollection values)
        {
            // Add the contact info to the database
            contactDb.AddNewContact(values["fullname"],values["emailAddress"],values["body"]);
            contactDb.SaveChanges();

            return Content("Thanks for your submission.");
        }
    }
}