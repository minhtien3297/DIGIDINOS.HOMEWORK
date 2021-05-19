using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cvManagement.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Your Name")]
        [StringLength(50, ErrorMessage = "Name should be less than or equal to 50 characters.")]
        public string Name { get; set; }

        public string PassWord { get; set; }

        public int Role { get; set; }

        public List<Account> listAccount;

        public Account account;

        public Account()
        {
        }

        public Account(int id, string name, string password, int role)
        {
            Id = id;
            Name = name;
            PassWord = password;
            Role = role;
        }
    }
}