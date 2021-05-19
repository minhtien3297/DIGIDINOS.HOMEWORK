using System.ComponentModel.DataAnnotations;

namespace cvManagement.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Position()
        {
        }

        public Position(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}