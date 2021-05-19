using System.ComponentModel.DataAnnotations;

namespace cvManagement.Models
{
    public class Source
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Source()
        {
        }

        public Source(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}