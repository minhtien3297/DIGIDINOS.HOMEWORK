using System;
using System.Collections.Generic;

namespace ReportManager.Models
{
    public class Comments
    {
        public int ID { get; set; }
        public string Contents { get; set; }
        public DateTime Dates { get; set; }
        public int Reports_ID { get; set; }
        public int Accounts_ID { get; set; }
        public List<Comments> ShowAllCmt { get; set; }
    }
}