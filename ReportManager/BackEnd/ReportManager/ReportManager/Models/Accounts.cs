using System.Collections.Generic;

namespace ReportManager.Models
{
    public class Accounts
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public int Sex { get; set; }
        public int Status { get; set; }
        public int Teams_ID { get; set; }
        public List<Accounts> ShowAllAccount { get; set; }
    }
}