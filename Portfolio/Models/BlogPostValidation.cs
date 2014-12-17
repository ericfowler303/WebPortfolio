using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// first step
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    // step 2 set the metadata type for the database object
    [MetadataType(typeof(BlogPostValidation))]
    public partial class BlogPost
    {

    }

    public class BlogPostValidation
    {
        // Layout the properties of the BlogPost
        [Required(ErrorMessage="Set a title for the blog post"), Display(Name="Blog Title")]
        public string Title { get; set; }

        [Required(ErrorMessage="Set a body for the post"), Display(Name="Blog Post Body"), DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [DataType(DataType.Url), Display(Name="Image URL")]
        public string ImageUrl { get; set; }
        [Display(Name="Date Created")]
        public DateTime DateCreated { get; set; }
    }
}