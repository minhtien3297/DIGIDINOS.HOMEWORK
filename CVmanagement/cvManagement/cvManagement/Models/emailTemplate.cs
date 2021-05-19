using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cvManagement.Models
{
    public class EmailTemplate
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the email type")]
        [StringLength(50, ErrorMessage = "Name should be less than or equal to 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the content")]
        public string Content { get; set; }

        public List<EmailTemplate> listTemplate { get; set; }

        public EmailTemplate()
        {
        }

        public EmailTemplate(int id, string name, string content, List<EmailTemplate> listTemplate)
        {
            Id = id;
            Name = name;
            Content = content;
            this.listTemplate = listTemplate;
        }
    }
}