using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoWebAPI.Models
{
    public class Comment
    {
        [Key]

        public int CommentID { get; set; }

        public string UserComment { get; set; }

        public DateTime? Commentdate { get; set; }
    }
}