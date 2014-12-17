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

        // Edit functions
        [HttpGet]
        public ActionResult Edit(int id)
        {
            // get the post to edit, Find() gets based on the primary key
            Models.BlogPost postToEdit = db.BlogPosts.Find(id);
            return View(postToEdit);
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.BlogPost editedBlogPost)
        {
            // first method to edit, get from the database then update
            /*Models.BlogPost databaseBlogPost = db.BlogPosts.Find(id);
            databaseBlogPost.Title = editedBlogPost.Title;
            databaseBlogPost.Body = editedBlogPost.Body;
            databaseBlogPost.ImageUrl = editedBlogPost.ImageUrl;
            // save changes
            db.SaveChanges();*/

            // second method
            db.Entry(editedBlogPost).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            // kick the user back to the index
            return RedirectToAction("Index", "BlogAdmin");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            // Get the post to delete
            Models.BlogPost postToDelete = db.BlogPosts.Find(id);
            return View(postToDelete);
        }

        [HttpPost]
        public ActionResult Delete(int id, Models.BlogPost postToDelete)
        {
            postToDelete = db.BlogPosts.Find(id);
            db.BlogPosts.Remove(postToDelete);
            db.SaveChanges();

            return RedirectToAction("Index", "BlogAdmin");
        }
    }
}