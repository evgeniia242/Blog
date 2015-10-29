using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Innlevering_1.Models
{
    public class Blog
    {
        public int BlogId { get; set; }

        //[Required (ErrorMessage = "Please enter your name.")]
        //[StringLength(30)]
        public virtual ApplicationUser Owner { get; set; }

        [Required(ErrorMessage = "Please enter blog titel.")]
        [DisplayName("Titel")]
        [StringLength(100)]
        public String BlogTitel { get; set; }

        public Boolean Closed { get; set; }
    }
}