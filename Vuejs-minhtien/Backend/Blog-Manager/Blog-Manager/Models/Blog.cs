using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogManager.Models
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public int Category { get; set; }
        public string Publics { get; set; }
        public string Position { get; set; }
        public string Thumbs { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [CustomValidationAttribute.ValidDate(ErrorMessage = "Date can not be greater than current date")]
        public DateTime DatePublic { get; set; }
        public List<Blog> ShowallBlogs { get; set; }
    }
}
