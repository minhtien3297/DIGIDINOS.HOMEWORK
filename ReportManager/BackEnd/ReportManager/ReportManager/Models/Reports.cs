using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReportManager.Models
{
    public class Reports
    {
        public int ID { get; set; }
        public string Done { get; set; }
        public string Problem { get; set; }
        public string Solution { get; set; }
        public string Link { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Dates { get; set; }

        public int Account_ID { get; set; }
        public int Teams_ID { get; set; }
        public List<Reports> ShowAllReport { get; set; }
    }
}