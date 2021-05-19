using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogManager.Models
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }

        [Required(ErrorMessage = "Enter Blog Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Your Blog description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter Blog Detail")]
        public string Detail { get; set; }

        public byte[] Photo { get; set; }

        public string Type { get; set; }

        public string Condition { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [BlogManager.Models.CustomValidationAttribute.ValidDate(ErrorMessage = "Date can not be greater than current date")]
        public DateTime Date { get; set; }

        public List<Blog> ShowAllBlog { get; set; }
    }
}