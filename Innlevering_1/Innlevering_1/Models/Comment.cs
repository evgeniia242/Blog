using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Innlevering_1.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public virtual Post Post { get; set; }

        [Required(ErrorMessage = "You can't submit empty comment.")]
        [DataType(DataType.MultilineText)]
        public String Text { get; set; }

        public DateTime Date { get; set; }
    }
}