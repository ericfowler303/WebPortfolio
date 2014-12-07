using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class BlogController : Controller
    {
        Models.BlogEntities dbEntities = new Models.BlogEntities();

        // GET: Blog
        public ActionResult Index()
        {
            var postList = dbEntities.BlogPosts.OrderByDescending(x => x.DateCreated);
            return View(postList);
        }
    }
}