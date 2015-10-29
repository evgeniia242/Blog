using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Innlevering_1.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public Blog Blog { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        [Required(ErrorMessage = "Please enter post title.")]
        public String PostTitle { get; set; }

        [Required (ErrorMessage="You can't submit empty post.")]
        [DataType(DataType.MultilineText)]
        public String Text { get; set; }

        public DateTime Date { get; set; }
    }
}