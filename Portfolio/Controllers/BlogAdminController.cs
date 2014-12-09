using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class BlogAdminController : Controller
    {
        // Create the database gateway for all actions
        Models.BlogEntities db = new Models.BlogEntities();

        // GET: BlogAdmin
        [HttpGet]
        public ActionResult Index()
        {
            // Will show all blog posts
            return View(db.BlogPosts);
        }

        // Get: Create a post
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Post: Make a new blog post in the database
        [HttpPost]
        public ActionResult Create(Models.BlogPost newPost)
        {
            // Set the blog post creation time
            newPost.DateCreated = DateTime.Now;
            // Add the new post to the database
            db.BlogPosts.Add(newPost);
            // save the changes to the database
            db.SaveChanges();
            // Send the user to the new view telling them that the post was submitted
            return View("PostSubmitted");
        }
    }
}